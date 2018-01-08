RegisterNUICallback("teleport", function(data, cb)
	local loc = stringsplit(data.action, ",")
	local x = tonumber(loc[1]) + 0.0
	local y = tonumber(loc[2]) + 0.0
	local z = tonumber(loc[3]) + 0.0
	local playerPed = GetPlayerPed(-1)
	local entity = playerPed

	if IsPedInAnyVehicle(playerPed, 0) then
		-- If the player is in a car, take it with them
		entity = GetVehiclePedIsIn(playerPed, 0)
	end

	SetEntityCoords(entity, x, y, z, 1, 0, 0, 1)

	cb("ok")
end)
--[[
RegisterNUICallback("coords", function(data, cb)
	local loc = GetEntityCoords(GetPlayerPed(PlayerId()))
	local coords = string.format("~g~%0.2f, %0.2f, %0.2f", loc.x, loc.y, loc.z)

	drawNotification(coords)

	cb("ok")
end)
]]
RegisterNUICallback("teleplayer", function(data, cb)
	local otherServerId = tonumber(data.action)
	local other = GetPlayerFromServerId(otherServerId)

	if other == PlayerId() then
		drawNotification("~r~Player " .. otherServerId .. " is you!")
	elseif not NetworkIsPlayerActive(other) then
		drawNotification("~r~Player " .. otherServerId .. " is not in the game.")
	else
		local playerPed = GetPlayerPed(-1)
		local otherPed = GetPlayerPed(other)
		local otherCoords = GetEntityCoords(otherPed)
		local otherVeh = GetVehiclePedIsIn(otherPed, 0)
		local seat = -1

		drawNotification("~g~Teleporting to " .. GetPlayerName(other) .. " (Player " .. otherServerId .. ").")

		if otherVeh then
			local numSeats = GetVehicleModelNumberOfSeats(GetEntityModel(otherVeh))

			if numSeats > 1 then
				for i = 0, numSeats do
					if seat == -1 and IsVehicleSeatFree(otherVeh, i) then
						seat = i
					end
				end
			end
		end

		if seat == -1 then
			SetEntityCoords(playerPed, otherCoords.x, otherCoords.y, otherCoords.z, 1, 0, 0, 1)
		else
			SetPedIntoVehicle(playerPed, otherVeh, seat)
		end
	end

	cb("ok")
end)

RegisterNUICallback("telelastcar", function(data, cb)
	local playerPed = GetPlayerPed(-1)
	local lastVeh = GetPlayersLastVehicle()
	local seat = -2

	if lastVeh then
		local numSeats = GetVehicleModelNumberOfSeats(GetEntityModel(lastVeh))

		SetVehicleOnGroundProperly(lastVeh)

		if numSeats > 0 then
			for i = -1, numSeats do
				if seat == -2 and IsVehicleSeatFree(lastVeh, i) then
					seat = i
				end
			end
		end
	else
		drawNotification("~r~Last vehicle not found!")
	end

	if seat == -2 and lastVeh then
		local otherCoords = GetEntityCoords(lastVeh)

		if otherCoords.x > 0 or otherCoords.y > 0 or otherCoords.z > 0 then
			SetEntityCoords(playerPed, otherCoords.x, otherCoords.y, otherCoords.z, 1, 0, 0, 1)
		end
	else
		SetPedIntoVehicle(playerPed, lastVeh, seat)
	end
end)
