﻿/// <reference path="./js_refs/index.d.ts" />
/// <reference path="./js_refs/jquery.d.ts" />
//// <reference path="./node_modules/vue/types/vue.d.ts" />

declare var Vue: any;

/** The name of the resource on the server */
const resourceName: string = 'virakal-trainer';

/** The maximum number of items on a page */
const maxPageSize: number = 12;

/** Text to show in the title bar */
const trainerTitle: string = 'Virakal Trainer';

interface MenuItem {
	text: string,
	sub?: string,
	image?: string,
	state?: string,
	action?: string,
	configkey?: string,
	key? : string,
}

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
	return page >= 0 && page < this.pageCount;
}

function nextPage(): void {
	console.log(`Current: ${this.page} Next: ${this.page + 1} PageCount: ${this.pageCount} NextExists: ${this.pageExists(this.page + 1)}`);
	if (this.pageExists(this.page + 1)) {
		this.showPage(this.page + 1);
	} else if (this.pageCount > 1) {
		this.showPage(0);
	}

	playSound('NAV_UP_DOWN');
}

function previousPage(): void {
	console.log(`Current: ${this.page} Prev: ${this.page - 1} PageCount: ${this.pageCount} PrevExists: ${this.pageExists(this.page - 1)}`);
	if (this.pageExists(this.page - 1)) {
		this.showPage(this.page - 1);
	} else if (this.pageCount > 1) {
		this.showPage(this.pageCount - 1);
	}

	playSound('NAV_UP_DOWN');
}

function selectUp(): void {
	this.selected = this.selected ? this.selected - 1 : this.menuPage.length - 1;
	playSound('NAV_UP_DOWN');
}

function selectDown(): void {
	this.selected = (this.selected + 1) % this.menuPage.length;
	playSound('NAV_UP_DOWN');
}

function resetTrainer(): void {
	this.showMenu('mainmenu');
}

function setMenu(menuName: string, menuData: MenuItem[]): void {
	console.log(`Receieved menu ${menuName}`);
	// console.log(JSON.stringify(menuData));
	this.menus[menuName] = menuData;

	if (this.currentMenuKey === menuName) {
		// Because the underlying menu has changed, we need to force the update
		console.log("Forcing the update");
		this.updateCurrentMenu();
	}
}

// Only use this if the underlying structure for the current menu is changed. Vue doesn't seem to like that.
function updateCurrentMenu(): void {
	const newMenuKey = this.currentMenuKey;
	// Briefly change the currentMenuKey to force a recompute
	this.currentMenuKey = 'mainmenu';
	this.$forceUpdate();
	this.currentMenuKey = newMenuKey;

	// If our selection is no longer available on the list, reset to 0
	if (this.selected >= this.currentMenu.length) {
		this.page = 0;
		this.selected = 0;
	}
}

function showMenu(menuName: string): void {
	if (!this.menus[menuName]) {
		console.log(`No such menu as '${menuName}'`);
		this.showMenu('mainmenu');
		return;
	}

	this.selected = 0;
	this.page = 0;
	this.currentMenuKey = menuName;
}

function handleSelection(): void {
	const sel: MenuItem = this.currentItem;
	
	if (sel.sub) {
		this.showMenu(sel.sub);
	} else if (sel.action) {
		console.log(`Doing ${sel.action}`);
		let newState: boolean = true;

		if (sel.state) {
			if (sel.state === "ON") {
				newState = false;
				sel.state = "OFF";
			} else {
				sel.state = "ON";
			}
		}

		// Not sure why I need this, but state updates no longer pass to the main menu
		this.$forceUpdate();

		const data: string[] = sel.action.split(' ');

		if (data[1] === '*') {
			console.log("Subdata not implemented");
			// data[1] = item.parent().attr('data-subdata');
		}

		if (data[0] === 'playerskin') {
			console.log("Recent skins not yet implemented");
			// addToRecentSkins(data[1], item);
		}

		console.log(`Sending ${data[0]}, action: ${data[1]}, newState: ${newState}`);
		sendData(data[0], { action: data[1], newstate: newState, itemtext: sel.text });
	}

	playSound('SELECT');
}

function goBack(): void {
	if (this.parentKey) {
		this.showMenu(this.parentKey);
	} else {
		this.closeTrainer();
	}

	playSound('BACK');
}

function openTrainer(): void {
	this.resetTrainer();
	this.showTrainer = true;
	playSound('YES');
}

function closeTrainer(): void {
	this.resetTrainer();
	this.showTrainer = false;
	sendData('trainerclose', {});
	playSound('NO');
}

function updateFromConfig(json: string): void {
	console.log("Not yet implemented");
	const config: { [key: string]: string; } = JSON.parse(json);

	for (const key in config) {
		let value = config[key];
		this.configState[key] = value;
	}

	/*
	// Hunt for menu items with config-key data set, then update them
	for (const menuName in menus) {
		let menuData = menus[menuName];

		for (const key in config) {
			menuData.pages.forEach(function (page) {
				page.forEach(function (trainerOption) {
					const match = trainerOption.is(`.traineroption[data-state][data-config-key="${key}"]`)

					if (match) {
						let value = config[key];

						if (value === "true") {
							trainerOption.attr('data-state', 'ON');
						} else if (value === "false") {
							trainerOption.attr('data-state', 'OFF');
						} else {
							console.log(`Unexpected value for a config key: ${value}!`);
						}
					}
				});
			});
		}
	}
	*/
}

function getStateFromConfig(configKey: string): boolean|undefined {
	return this.configState[configKey];
}

function getStateText(configKey: string): string {
	return this.getStateFromConfig(configKey) ? 'ON' : 'OFF';
}

function getItemKey(item: MenuItem): string {
	return item.key || item.text;
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
	template: '<p id="pageindicator">Page {{ page + 1 }} / {{ pageCount }}</p>',
});

/**
 * The floating preview image that shows cars, etc.
 */
Vue.component('preview-image', {
	props: ['img'],
	template: '<div id="imagecontainer" v-if="img"><img :src="img"></div>',
});

const app = new Vue({
	el: '#vuecontainer',
	data: {
		trainerTitle,
		maxPageSize,
		showTrainer: false,
		menus: {},
		currentMenuKey: 'mainmenu',
		page: 0,
		selected: 0,
		recentSkins: [],
		configState: {},
	},
	computed: {
		pageCount: function (): number {
			return 1 + Math.floor(this.menus[this.currentMenuKey].length / this.maxPageSize);
		},
		menuPage: function (): MenuItem[] {
			return this.menus[this.currentMenuKey].slice(this.page * this.maxPageSize, (this.page + 1) * this.maxPageSize);
		},
		currentItem: function (): MenuItem {
			const currentIndex = this.page * this.maxPageSize + this.selected;
			return this.menus[this.currentMenuKey][currentIndex];
		},
		currentImage: function (): string {
			const currentIndex = this.page * this.maxPageSize + this.selected;
			return this.menus[this.currentMenuKey][currentIndex] ? this.menus[this.currentMenuKey][currentIndex].image : null;
		},
		currentMenu: function (): MenuItem {
			return this.menus[this.currentMenuKey];
		},
		parentKey: function (): string|boolean {
			// The main menu has no parent
			if (this.currentMenuKey === "mainmenu") {
				return false;
			}

			const lastDot = this.currentMenuKey.lastIndexOf(".");

			// A key without a dot is a top-level one, so the parent is the main menu
			if (lastDot === -1) {
				return "mainmenu";
			}

			// Get the string up to the last dot, so a.b.c returns a.b
			return this.currentMenuKey.substring(0, lastDot);
		}
	},
	methods: {
		showPage,
		nextPage,
		previousPage,
		pageExists,
		selectUp,
		selectDown,
		resetTrainer,
		setMenu,
		showMenu,
		handleSelection,
		goBack,
		openTrainer,
		closeTrainer,
		updateFromConfig,
		getStateFromConfig,
		getStateText,
		getItemKey,
		updateCurrentMenu,
	},
});

window.addEventListener('message', function (event) {
	let item = event.data;

	if (item.showtrainer) {
		app.openTrainer();
	} else if (item.hidetrainer) {
		app.closeTrainer();
	}

	if (item.trainerenter) {
		app.handleSelection();
	} else if (item.trainerback) {
		app.goBack();
	}

	if (item.trainerleft) {
		app.previousPage();
	} else if (item.trainerright) {
		app.nextPage();
	}

	if (item.trainerup) {
		app.selectUp();
	} else if (item.trainerdown) {
		app.selectDown();
	}

	if (item.setmenu) {
		app.setMenu(item.menuname, item.menudata);
	}
});
