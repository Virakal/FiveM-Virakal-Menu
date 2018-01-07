local config = Virakal.Config
local justRunSpawnHandler

Citizen.Trace("JG ------------------------- LOADED SCRIPT")

config.setDefaults({
	godmode = false,
	infiniteStamina = true,
	currentSkin = nil,
})

RegisterNUICallback("player", function(data, cb)
	local playerPed = GetPlayerPed(-1)
	local action = data.action
	local newstate = data.newstate

	if action == "heal" then
		SetEntityHealth(playerPed, 200)
		drawNotification("~g~Player healed.")
	elseif action == "armor" then
		SetPedArmour(playerPed, 100)
		drawNotification("~g~Added armor to Player.")
	elseif action == "suicide" then
		SetEntityHealth(playerPed, 0)
		drawNotification("~g~Killed Player.")
	elseif action == "god" then
		config.set('godmode', newstate)
	elseif action == "stamina" then
		config.set('infiniteStamina', newstate)
	elseif action == "ammo" then
		SetPedInfiniteAmmo(playerPed, newstate)
	elseif action == "clip" then
		SetPedInfiniteAmmoClip(playerPed, newstate)
	elseif action == "autochute" then
		SetAutoGiveParachuteWhenEnterPlane(playerPed, newstate)
	end

	cb("ok")
end)

RegisterNUICallback("playerskin", function(data, cb)
	local model = GetHashKey(data.action)
	local playerPed = GetPlayerPed(-1)
	local playerVeh = GetVehiclePedIsIn(playerPed, false)
	local playerSeat = -99

	-- Record the behicle seat the player was in, so we can put them back if we need to
	if playerVeh then
		local numSeats = GetVehicleModelNumberOfSeats(GetEntityModel(playerVeh))
		local found = false

		if numSeats > 0 then
			for i = -1, numSeats do
				if not found and GetPedInVehicleSeat(playerVeh, i) == playerPed then
					playerSeat = i
					found = true
				end
			end
		end
	end

	SetCharModel(PlayerId(), model)

	-- Record the chosen skin
	config.set('currentSkin', model)

	TriggerEvent("playerSpawned")
	TriggerEvent("virakal:skinChange", model)
	drawNotification("~g~Changed Player Model.")

	SetModelAsNoLongerNeeded(model)

	-- Put the player back in their seat
	if playerVeh and playerSeat >= -1 then
		-- Get the new ped
		playerPed = GetPlayerPed(-1)
		SetPedIntoVehicle(playerPed, playerVeh, playerSeat)
	end

	cb("ok")
end)

Citizen.CreateThread(function()
	while true do
		Wait(1)

		local playerPed = GetPlayerPed(-1)
		if playerPed then
			SetEntityInvincible(playerPed, godmode)

			if config.get('infiniteStamina') then
				RestorePlayerStamina(PlayerId(), 1.0)
			end
		end
	end
end)

AddEventHandler("playerSpawned", function()
	Citizen.Wait(0)

	-- Guard against infinite recursion
	if justRunSpawnHandler then
		justRunSpawnHandler = false
		return
	end

	local playerPed = GetPlayerPed(-1)
	local actualSkin = GetEntityModel(playerPed)
	local currentSkin = config.get('currentSkin')

	if actualSkin ~= currentSkin then
		SetCharModel(PlayerId(), currentSkin)
		justRunSpawnHandler = true
		TriggerEvent("playerSpawned", currentSkin)
	end
end)

AddEventHandler("virakal:skinChange", function(model)
	Citizen.Wait(0)

	local playerPed = GetPlayerPed(-1)

	if not IsPedHuman(playerPed) then
		-- Fix some animal skins
		SetPedComponentVariation(playerPed, 0, 0, 0, 0)
	elseif model == GetHashKey('mp_m_freemode_01') then
		-- Make male MP player visible (from Flatracer)
		SetPedHeadBlendData(playerPed, 4, 4, 0, 4, 4, 0, 1.0, 1.0, 0.0, false)
		SetPedComponentVariation(playerPed, 2, 2, 4, 0)
		SetPedComponentVariation(playerPed, 3, 1, 0, 0)
		SetPedComponentVariation(playerPed, 4, 33, 0, 0)
		SetPedComponentVariation(playerPed, 5, 45, 0, 0)
		SetPedComponentVariation(playerPed, 6, 25, 0, 0)
		SetPedComponentVariation(playerPed, 8, 56, 1, 0)
		SetPedComponentVariation(playerPed, 11, 49, 0, 0)
	elseif model == GetHashKey('mp_f_freemode_01') then
		-- Make female MP player visible (from Flatracer)
		SetPedHeadBlendData(playerPed, 25, 25, 0, 25, 25, 0, 1.0, 1.0, 0.0, false)
		SetPedComponentVariation(playerPed, 2, 13, 3, 0)
		SetPedComponentVariation(playerPed, 3, 3, 0, 0)
		SetPedComponentVariation(playerPed)
		SetPedComponentVariation(playerPed, 5, 45, 0, 0)
		SetPedComponentVariation(playerPed, 6, 25, 0, 0)
		SetPedComponentVariation(playerPed, 8, 33, 1, 0)
		SetPedComponentVariation(playerPed, 11, 42, 0, 0)
	end
end)

function SetCharModel(playerId, model)
	RequestModel(model)

	while not HasModelLoaded(model) do
		Citizen.Wait(1)
	end

	SetPlayerModel(playerId, model)
end
