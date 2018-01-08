local config = Virakal.Config

config.setDefault('explosiveAmmo', false)
config.setDefault('fireAmmo', false)

RegisterNUICallback("wepgive", function(data, cb)
	local playerPed = GetPlayerPed(-1)
	local weapon = data.action

	GiveWeaponToPed(playerPed, GetHashKey(weapon), 9999, true, true)

	cb("ok")
end)

RegisterNUICallback("wepremove", function(data, cb)
	local playerPed = GetPlayerPed(-1)
	local weapon = data.action

	RemoveWeaponFromPed(playerPed, GetHashKey(weapon))

	cb("ok")
end)
--[[
RegisterNUICallback("explosiveammo", function(data, cb)
	config.set('explosiveAmmo', data.newstate)

	cb("ok")
end)


RegisterNUICallback("fireammo", function(data, cb)
	config.set('fireAmmo', data.newstate)

	cb("ok")
end)

Citizen.CreateThread(function ()
	while true do
		Citizen.Wait(0)

		local playerPed = PlayerId(-1)

		if config.get('fireAmmo') then
			SetFireAmmoThisFrame(playerPed)
		end

		if config.get('explosiveAmmo') then
			SetExplosiveAmmoThisFrame(playerPed)
		end
	end
end)
]]