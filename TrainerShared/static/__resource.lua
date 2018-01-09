resource_manifest_version '05cfa83c-a124-4cfa-a768-c24a5811d8f9'

ui_page "nui/trainer.html"

server_script '@mysql-async/lib/MySQL.lua'

files {
	"nui/trainer.html",
	"nui/trainer.js",
	"nui/trainer.css",
	"nui/Roboto.ttf",
	"Newtonsoft.Json.dll"
}

client_script {
	'TrainerShared.net.dll',
	'TrainerClient.net.dll',
	'main.lua',
	'config.lua',
	'vehicles.lua'
}

server_script {
	'TrainerShared.net.dll',
	'TrainerServer.net.dll',
	'server.lua'
}
