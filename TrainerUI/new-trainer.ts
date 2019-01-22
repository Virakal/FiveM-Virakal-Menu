/// <reference path="./js_refs/index.d.ts" />
/// <reference path="./js_refs/jquery.d.ts" />
//// <reference path="./node_modules/vue/types/vue.d.ts" />

declare var Vue: any;

/** The name of the resource on the server */
const resourceName: string = 'virakal-trainer';

/** The maximum number of items on a page */
const maxPageSize: number = 3;

function sendData(name: string, data: any): JQueryXHR {
	return $.post(`http://${resourceName}/${name}`, JSON.stringify(data), function (response) {
		// console.log('Data response: ' + response);
	});
}

function playSound(sound: string): void {
	sendData('playsound', { name: sound });
}

function showPage(page: number): void {
	this.page = page;
	this.selected = 0;
}

function pageExists(page: number): boolean {
	return page >= 0 && page <= this.pageCount;
}

function nextPage(): void {
	if (this.pageExists(this.page + 1)) {
		this.showPage(this.page + 1);
	} else {
		this.showPage(0);
	}

	playSound('NAV_UP_DOWN');
}

function previousPage(): void {
	if (this.pageExists(this.page - 1)) {
		this.showPage(this.page - 1);
	} else {
		this.showPage(this.pageCount - 1);
	}

	playSound('NAV_UP_DOWN');
}

/**
 * An individual menu item
 */
Vue.component('trainer-option', {
	props: ['text', 'sub', 'action', 'state', 'image'],
	template: '<p class="traineroption" :data-sub="sub" :data-action="action" :data-state="state" :data-image="image"><slot></slot></p>',
});

/**
 * The indicator for the current page
 */
Vue.component('page-indicator', {
	props: ['page', 'pageCount'],
	template: '<p id="pageindicator">Page {{ page + 1 }} / {{ pageCount + 1 }}</p>',
});

let menus = {
	mainMenu: [
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
	],
};

let app = new Vue({
	el: '#trainercontainer',
	data: {
		trainerTitle: 'Virakal Trainer',
		showTrainer: false,
		currentMenu: menus.mainMenu,
		page: 0,
		selected: 0,
		maxPageSize: maxPageSize,
	},
	computed: {
		pageCount: function () {
			return Math.floor((this.currentMenu.length - 1) / this.maxPageSize);
		},
		menuPage: function () {
			return this.currentMenu.slice(this.page * this.maxPageSize, (this.page + 1) * this.maxPageSize);
		}
	},
	methods: {
		showPage,
		nextPage,
		previousPage,
		pageExists,
	},
});

window.addEventListener('message', function (event) {
	let item = event.data;

	if (item.showtrainer) {
		app.showTrainer = true;
	} else if (item.hidetrainer) {
		app.showTrainer = false;
	}

	if (item.trainerleft) {
		app.previousPage();
	} else if (item.trainerright) {
		app.nextPage();
	}
});
