local first_spawn = true

RegisterNetEvent("virakal:setWeather")
RegisterNetEvent("virakal:setTime")

local function ChangeWeather(weather)
	SetWeatherTypePersist(weather)
	SetWeatherTypeNowPersist(weather)
	SetWeatherTypeNow(weather)
	SetOverrideWeather(weather)
end

RegisterNUICallback("weather", function(data, cb)
	TriggerServerEvent("virakal:changeWeather", data.action)
	cb("ok")
end)

RegisterNUICallback("time", function(data, cb)
	local time = tonumber(data.action)

	TriggerServerEvent("virakal:changeTime", time, 0, 0)
	cb("ok")
end)

AddEventHandler("playerSpawned", function(spawn)
	if first_spawn then
		first_spawn = false
		TriggerServerEvent("virakal:requestWeather")
		TriggerServerEvent("virakal:requestTime")
		TriggerServerEvent("virakal:requestConfig")
	end
end)

AddEventHandler("virakal:setWeather", function(weather, name)
	if not weather then
		return
	end

	ChangeWeather(weather)

	if name then
		drawNotification("~g~Weather changed to " .. weather .. " by " .. name .. ".")
	end
end)

AddEventHandler("virakal:setTime", function(h, m, s, name)
	NetworkOverrideClockTime(h, m, s)

	if name then
		drawNotification(string.format("~g~Time changed to %02d:%02d:%02d by %s.", h, m, s, name))
	end
end)
