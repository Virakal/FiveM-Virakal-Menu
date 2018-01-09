--[[
local current_weather
local current_time
local dbReady = false

RegisterServerEvent("virakal:setConfig")
RegisterServerEvent("virakal:changeWeather")
RegisterServerEvent("virakal:changeTime")
RegisterServerEvent("virakal:requestWeather")
RegisterServerEvent("virakal:requestTime")
RegisterServerEvent("virakal:requestConfig")


AddEventHandler("virakal:changeWeather", function(weather)
	local name = GetPlayerName(source)

	print("Weather changed to " .. weather .. " by " .. name)

	current_weather = weather
	TriggerClientEvent('virakal:setWeather', -1, weather, name)
end)


AddEventHandler("virakal:changeTime", function(h, m, s)
	local name = GetPlayerName(source)

	print(string.format("Time changed to %02d:%02d:%02d by %s.", h, m, s, name))

	current_time = {h, m, s}
	TriggerClientEvent('virakal:setTime', -1, h, m, s, name)
end)

--[[
AddEventHandler("virakal:requestWeather", function()
	if current_weather then
		TriggerClientEvent('virakal:setWeather', source, current_weather, nil)
	end
end)


AddEventHandler("virakal:requestTime", function()
	if current_time then
		TriggerClientEvent('virakal:setTime', source, current_time[0], current_time[1], current_time[2], nil)
	end
end)
--[[
AddEventHandler('virakal:setConfig', function (key, val)
	Citizen.Trace("Setting config - K:" .. tostring(key) .. ", V: " .. tostring(val) .. ", type: " .. type(val) .. "\n")

	local stringVal

	if type(val) == 'boolean' then
		stringVal = tostring(val)
	end

	if type(stringVal) == 'string' then
		MySQL.Async.execute([[
			REPLACE INTO virakal_config (
				`player_id`,
				`key`,
				`value`,
				`type`
			) VALUES (
				@id,
				@key,
				@value,
				@type
			)
		]]--[[, {
			id = getSteamID(source),
			key = key,
			value = stringVal,
			type = type(val)
		})
	end
end)

AddEventHandler('virakal:requestConfig', function ()
	MySQL.Async.fetchAll(
		"SELECT * FROM virakal_config WHERE player_id = @id",
		{id = getSteamID(source)},
		function (res)
			local config = {}

			for k, v in pairs(res) do
				Citizen.Trace(v.key)
				Citizen.Trace(v.value)
			end

			TriggerClientEvent('virakal:config:updateFromDB', source, config)
		end
	)
end)

MySQL.ready(function ()
	Citizen.Trace("Virakal DB Ready\n")
	TriggerClientEvent('virakal:dbReady', -1)
end)

function getSteamID(source)
	local ids = GetPlayerIdentifiers(source)

	for k, v in pairs(ids) do
		if string.sub(v, 1, 6) == 'steam:' then
			return v
		end
	end
end
]]