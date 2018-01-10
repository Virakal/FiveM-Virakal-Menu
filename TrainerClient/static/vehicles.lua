local config = Virakal.Config

config.setDefaults({
	despawnablecar = true,
	boostcar = false,
	rainbowcar = false,
	rainbowchrome = false,
	rainbowneon = false,
	rainbowneoninverse = false,
	invinciblecar = true,
	spawninveh = false,
})
--[[
local function _SetEntityAsNoLongerNeeded(entity)
	Citizen.InvokeNative(0xB736A491E64A32CF, Citizen.PointerValueIntInitialized(entity))
end

local function SpawnVehicle(model, x, y, z)
	if IsModelValid(model) then
		RequestModel(model)

		while not HasModelLoaded(model) do
			Wait(1)
		end

		local veh = CreateVehicle(model, x + 2.5, y + 2.5, z + 1, 0.0, true, true)

		if config.get('despawnablecar') then
			_SetEntityAsNoLongerNeeded(veh)
		end

		drawNotification("~g~Vehicle spawned!")

		if veh and config.get('spawninveh') then
			local playerPed = GetPlayerPed(-1)
			local playerVeh = GetVehiclePedIsIn(playerPed, false)

			-- Move them into the new vehicle
			SetPedIntoVehicle(playerPed, veh, -1)

			-- Move any passengers into the new vehicle, if they fit and the changer was driving (broken currently)
			local newSeats = GetVehicleModelNumberOfSeats(GetEntityModel(veh))
			local oldSeats = GetVehicleModelNumberOfSeats(GetEntityModel(playerVeh))
			local allocated = 0

			for i = 0, oldSeats do
				Citizen.Trace("Seat " .. i .. " Allocated " .. allocated)
				if allocated < newSeats then
					local ped = GetPedInVehicleSeat(playerVeh, i)

					if ped > 0 then
						SetPedIntoVehicle(ped, veh, -2)
						allocated = allocated + 1
					end
				end
			end

			-- Remove the old vehicle (must be a mission entity)
			SetEntityAsMissionEntity(playerVeh, true, true)
			DeleteEntity(playerVeh)
		end
	else
		drawNotification("~r~Invalid Model!")
	end
end

RegisterNUICallback("veh", function(data, cb)
	local playerPed = GetPlayerPed(-1)
	local playerVeh = GetVehiclePedIsIn(playerPed, false)
	local action = data.action

	if action == "fix" then
		if not playerVeh then
			drawNotification("~r~Not in a vehicle!")
			return
		end

		SetVehicleFixed(playerVeh)
		drawNotification("~g~Vehicle repaired.")
	elseif action == "clean" then
		if not playerVeh then
			drawNotification("~r~Not in a vehicle!")
			return
		end

		SetVehicleDirtLevel(playerVeh, 0.0)
		drawNotification("~g~Vehicle cleaned.")
	elseif action == "flip" then
		SetVehicleOnGroundProperly(playerVeh)
	elseif action == "neonon" then
		for i = 0, 3 do
			SetVehicleNeonLightEnabled(playerVeh, i, true)
		end
	elseif action == "neonoff" then
		for i = 0, 3 do
			SetVehicleNeonLightEnabled(playerVeh, i, false)
		end
	elseif action == "boosthorn" then
		config.set('boostcar', data.newstate)
	elseif action == "rainbowcar" then
		config.set('rainbowcar', data.newstate)
	elseif action == "rainbowchrome" then
		ClearVehicleCustomPrimaryColour(playerVeh)
		ClearVehicleCustomSecondaryColour(playerVeh)
		SetVehicleColours(playerVeh, 120, 120)

		config.set('rainbowchrome', data.newstate)
	elseif action == "rainbowneon" then
		config.set('rainbowneon', data.newstate)
	elseif action == "rainbowneoninverse" then
		config.set('rainbowneoninverse', data.newstate)
	elseif action == "invincible" then
		config.set('invinciblecar', data.newstate)
	end

	cb("ok")
end)


RegisterNUICallback("vehspawn", function(data, cb)
	local playerPed = GetPlayerPed(-1)
	local x, y, z = table.unpack(GetEntityCoords(playerPed, true))

	if data.action == "despawn" then
		config.set('despawnablecar', data.newstate)
		return
	elseif data.action == "spawninveh" then
		config.set('spawninveh', data.newstate)
		return
	elseif data.action == "input" then
		DisplayOnscreenKeyboard(1, "FMMC_KEY_TIP8", "", "", "", "", "", 25)
		blockinput = true

		while UpdateOnscreenKeyboard() ~= 1 and UpdateOnscreenKeyboard() ~= 2 do
			Wait(1)
		end

		local result = GetOnscreenKeyboardResult()
		if result then
			SpawnVehicle(GetHashKey(string.upper(result)), x, y, z)
		end

		blockinput = false
		return
	end

	local playerVeh = GetVehiclePedIsIn(playerPed, false)
	local vehhash = GetHashKey(data.action)
	local veh = SpawnVehicle(vehhash, x, y, z)

	cb("ok")
end)
]]
RegisterNUICallback("vehcolor", function(data, cb)
	local playerPed = GetPlayerPed(-1)
	local playerVeh = GetVehiclePedIsIn(playerPed, false)
	local color = stringsplit(data.action, ",")
	local r = tonumber(color[1])
	local g = tonumber(color[2])
	local b = tonumber(color[3])

	if not playerVeh then
		drawNotification("~r~Not in a vehicle!")
		return
	end

	SetVehicleCustomPrimaryColour(playerVeh, r, g, b)
	SetVehicleCustomSecondaryColour(playerVeh, r, g, b)
	drawNotification("~g~Repainted vehicle!")

	cb("ok")
end)

--[[
RegisterNUICallback("vehprimary", function(data, cb)
	local playerPed = GetPlayerPed(-1)
	local playerVeh = GetVehiclePedIsIn(playerPed, false)
	local color = tonumber(data.action)

	if not playerVeh then
		drawNotification("~r~Not in a vehicle!")
		return
	end

	-- Clear custom colours
	ClearVehicleCustomPrimaryColour(playerVeh)
	ClearVehicleCustomSecondaryColour(playerVeh)

	SetVehicleColours(playerVeh, color, color)

	drawNotification("~g~Repainted vehicle!")

	cb("ok")
end)


RegisterNUICallback("vehpearl", function(data, cb)
	local playerPed = GetPlayerPed(-1)
	local playerVeh = GetVehiclePedIsIn(playerPed, false)
	local colour = tonumber(data.action)

	if not playerVeh then
		drawNotification("~r~Not in a vehicle!")
		return
	end

	local oldPearl, oldRim = GetVehicleExtraColours(playerVeh, false)

	SetVehicleExtraColours(playerVeh, colour, oldRim)

	cb("ok")
end)

Citizen.CreateThread(function() --Boost On Horn
	while true do
		local playerVeh, playerPed

		Citizen.Wait(0)

		if (config.get('boostcar') == true) then
			playerPed = GetPlayerPed(-1)
			playerVeh = GetVehiclePedIsIn(playerPed, false)

			if IsPedInAnyVehicle(playerPed, true) then
				if IsControlPressed(1, 71) and IsControlPressed(1, 86) then
					SetVehicleBoostActive(playerVeh, 1, 0)
					SetVehicleForwardSpeed(playerVeh, 75.0)
				elseif IsControlPressed(1, 72) and IsControlPressed(1, 86) then
					SetVehicleBoostActive(playerVeh, 1, 0)
					SetVehicleForwardSpeed(playerVeh, -75.0)
				end

				SetVehicleBoostActive(playerVeh, 0, 0)
			end
		end
	end
end)

Citizen.CreateThread(function() --Rainbow Car
	while true do
		Citizen.Wait(100)

		if config.get('rainbowcar') or config.get('rainbowchrome') or config.get('rainbowneon') or config.get('rainbowneoninverse') then
			local playerPed = GetPlayerPed(-1)
			local playerVeh = GetVehiclePedIsIn(playerPed, false)

			if GetPedInVehicleSeat(playerVeh, -1) == playerPed then
				local rgb = RGBRainbow(0.5)

				if IsPedInAnyVehicle(playerPed, true) then
					if config.get('rainbowcar') or config.get('rainbowchrome') then
						SetVehicleCustomPrimaryColour(playerVeh, rgb.r, rgb.g, rgb.b)
						SetVehicleCustomSecondaryColour(playerVeh, rgb.r, rgb.g, rgb.b)
					end

					if config.get('rainbowneoninverse') then
						local irgb = InvertRGB(rgb)
						SetVehicleNeonLightsColour(playerVeh, irgb.r, irgb.g, irgb.b)
					elseif config.get('rainbowneon') then
						SetVehicleNeonLightsColour(playerVeh, rgb.r, rgb.g, rgb.b)
					end

					Citizen.Wait(250)
				end
			end
		end
	end
end)


Citizen.CreateThread(function() -- Invincible Car
	local lastVeh

	while true do
	return
		Citizen.Wait(0)

		local playerPed = GetPlayerPed(-1)
		local playerVeh = GetVehiclePedIsIn(playerPed, false)
		local invincible = config.get('invinciblecar')

		if playerVeh > 0 then
			SetVehicleCanBeVisiblyDamaged(playerVeh, not invincible)
			SetVehicleTyresCanBurst(playerVeh, not invincible)
			SetEntityInvincible(playerVeh, invincible)
			SetEntityProofs(playerVeh, invincible, invincible, invincible, invincible, invincible, invincible, invincible, invincible)
			SetVehicleWheelsCanBreak(playerVeh, not invincible)
			SetVehicleExplodesOnHighExplosionDamage(playerVeh, not invincible)
			SetEntityOnlyDamagedByPlayer(playerVeh, not invincible)
			SetEntityCanBeDamaged(playerVeh, not invincible)

			if invincible and playerVeh ~= lastVeh then
				lastVeh = playerVeh
				SetVehicleFixed(playerVeh)
				SetVehicleDirtLevel(playerVeh, 0.0)
				SetVehicleEngineHealth(playerVeh, 1000.0)
			end
		else
			lastVeh = nil
		end

	end
end)

function RGBRainbow(frequency) -- Get a progressing rainbow colour based on game time
	local result = {}
	local gameTimer = GetGameTimer()

	result.r = math.floor(math.sin((gameTimer / 5000) * frequency + 0) * 127 + 128)
	result.g = math.floor(math.sin((gameTimer / 5000) * frequency + 2) * 127 + 128)
	result.b = math.floor(math.sin((gameTimer / 5000) * frequency + 4) * 127 + 128)

	return result
end

function InvertRGB(rgb)
	local result = {}

	result.r = 255 - rgb.r
	result.g = 255 - rgb.g
	result.b = 255 - rgb.b

	return result
end
]]