local config = Virakal.Config

config.setDefault('disablePolice', false)

RegisterNUICallback("wantedlevel", function(data, cb)
	local wanted = tonumber(data.action)
	local player = PlayerId()

	SetPlayerWantedLevel(player, wanted, false)
	SetPlayerWantedLevelNow(player, false)

	drawNotification("~g~Changed wanted level to " .. wanted .. ".")

	cb("ok")
end)

--[[
RegisterNUICallback("policeignore", function(data, cb)
	SetPoliceIgnorePlayer(PlayerId(), data.newstate)

	cb("ok")
end)
]]

RegisterNUICallback("policedisable", function(data, cb)
	config.set('disablePolice', data.newstate)
	cb("ok")
end)

Citizen.CreateThread(function ()
	local player = PlayerId()

	while true do
		Citizen.Wait(0)

		if config.get('disablePolice') then
			SetPlayerWantedLevel(player, 0, false)
			SetPlayerWantedLevelNow(player, false)
		end
	end
end)
