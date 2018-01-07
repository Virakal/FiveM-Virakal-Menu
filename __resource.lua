resource_manifest_version '05cfa83c-a124-4cfa-a768-c24a5811d8f9'

ui_page "nui/trainer.html"

files {
	"nui/trainer.html",
	"nui/trainer.js",
	"nui/trainer.css",
	"nui/Roboto.ttf"
}

client_script {
	'VirakalTrainerShared.net.dll',
	'VirakalTrainerClient.net.dll'
}

server_script {
	'VirakalTrainerShared.net.dll',
	'VirakalTrainerServer.net.dll'
}
