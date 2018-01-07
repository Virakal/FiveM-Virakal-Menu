local delta = {}

RegisterNetEvent('virakal:dbReady')
RegisterNetEvent('virakal:config:updateFromDB')

Virakal = {}
Virakal.Config = (function ()
	self = {}
	self.config = {}
	self.defaults = {}

	rObj = {}

	rObj.get = function (key)
		local val = self.config[key]

		if val ~= nil then
			return val
		end

		if self.defaults[key] ~= nil then
			return self.defaults[key]
		end
	end

	rObj.set = function (key, val)
		self.config[key] = val
		TriggerEvent('virakal:config:set', key, val)
	end

	rObj.setDefaults = function (table)
		for key, val in pairs(table) do
			self.defaults[key] = val
		end
	end

	rObj.setDefault = function (key, val)
		rObj.setDefaults({key = val})
	end

	rObj._dump = function ()
		local table = {}

		for k, v in pairs(self.config) do
			self[k] = v
		end
	end

	return rObj
end)()

AddEventHandler('virakal:dbReady', function ()
	Citizen.Trace('Requesting config')
	TriggerServerEvent('virakal:requestConfig')
end)

AddEventHandler('virakal:config:set', function (key, val)
	delta[key] = val
end)

AddEventHandler('virakal:config:updateFromDB', function (config)
	Citizen.Trace("Got config vars: " .. #config)
end)

Citizen.CreateThread(function() -- Update DB every 10 secs
	while true do
		Citizen.Trace("Updating server config, delta amount: " .. #delta)

		for k, v in pairs(delta) do
			TriggerServerEvent('virakal:setConfig', k, v)
		end

		delta = {}

		Citizen.Wait(10000)
	end
end)
