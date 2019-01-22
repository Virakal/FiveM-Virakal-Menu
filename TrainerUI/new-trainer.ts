/// <reference path="./js_refs/index.d.ts" />
/// <reference path="./js_refs/jquery.d.ts" />
//// <reference path="./node_modules/vue/types/vue.d.ts" />

declare var Vue: any;
const resourceName: string = 'virakal-trainer';

function sendData(name: string, data: any): JQueryXHR {
	return $.post(`http://${resourceName}/${name}`, JSON.stringify(data), function (response) {
		// console.log('Data response: ' + response);
	});
}

function playSound(sound: string): void {
	sendData('playsound', { name: sound });
}

window.addEventListener('message', function (event) {
	let item = event.data;

	if (item.showtrainer) {
		app.showTrainer = true;
	} else if (item.hidetrainer) {
		app.showTrainer = false;
	}
});

Vue.component('trainer-option', {
	props: ['text', 'sub', 'action', 'state'],
	template: '<p class="traineroption" :data-sub="sub" :data-action="action" :data-state="state"><slot></slot></p>',
});

let mainMenu = [
	{
        text: "Player",
		sub: "playermenu",
	},
	{
        text: "Teleport",
		sub: "teleportmenu",
	},
	{
        text: "Vehicles",
		sub: "vehiclesmenu",
	},
	{
        text: "Weapons",
		sub: "weaponsmenu",
	},
	{
        text: "Police",
		sub: "policemenu",
	},
	{
        text: "Settings",
		sub: "settingsmenu",
	},
	{
        text: "Animate",
		sub: "animationmenu",
	},
	{
        text: "UI",
		sub: "uimenu",
	},
	{
        text: "Animal Bombs",
		sub: "animalbombmenu",
	},
];

let app = new Vue({
	el: '#trainercontainer',
	data: {
		trainerTitle: 'Virakal Trainer',
		showTrainer: false,
		page: mainMenu
	}
});
