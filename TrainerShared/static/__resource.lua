resource_manifest_version '05cfa83c-a124-4cfa-a768-c24a5811d8f9'

-- ui_page "nui/trainer.html"
ui_page "nui/new-trainer.htm"

files {
	-- "nui/trainer.html",
	"nui/new-trainer.htm",
	-- "nui/trainer.js",
	"nui/new-trainer.js",
	"nui/trainer.css",
	"nui/Roboto.ttf",
	"Newtonsoft.Json.dll"
}

client_script {
	'TrainerShared.net.dll',
	'TrainerClient.net.dll'
}

server_script {
	'TrainerShared.net.dll',
	'TrainerServer.net.dll'
}
