resource_manifest_version '05cfa83c-a124-4cfa-a768-c24a5811d8f9'

ui_page "nui/index.html"

files {
    "nui/index.html",
    "nui/js/app.js",
    "nui/js/app.js.map",
    "nui/js/chunk-vendors.js",
    "nui/js/chunk-vendors.js.map",
    "nui/css/app.css",
    "nui/fonts/Roboto.ttf",
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
