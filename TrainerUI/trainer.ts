﻿/// <reference path="./js_refs/index.d.ts"/>
/// <reference path="./js_refs/jquery.d.ts"/>

/** CONFIG **/

// !! Change this to your current resource name !!
const resourceName: string = 'virakal-trainer';

// Max amount of items in 1 menu (before autopaging kicks in)
const maxVisibleItems: number = 12;

/** CODE **/

interface PageData {
	menu: JQuery,
	pages: JQuery[][],
	maxPages: number,
};

var counter: number;
var currentPage: number;

var menus: { [menuName: string]: PageData } = {};

var container: JQuery;
var content: PageData;
var maxPerPage: number;

var pageIndicator: string = '<p id="pageindicator"></p>';

var recentSkins: [string, JQuery][] = [];

$(function () {
	container = $('#trainercontainer');

	init();

	window.addEventListener('message', function (event) {
		let item = event.data;

		if (item.showtrainer) {
			resetTrainer();
			container.show();
			playSound('YES');
		} else if (item.hidetrainer) {
			container.hide();
			playSound('NO');
		}

		if (item.trainerenter) {
			handleSelectedOption();
		} else if (item.trainerback) {
			trainerBack();
		}

		if (item.trainerup) {
			trainerUp();
		} else if (item.trainerdown) {
			trainerDown();
		}

		if (item.trainerleft) {
			trainerPrevPage();
		} else if (item.trainerright) {
			trainerNextPage();
		}
	});
});

function init() {
	$('div').each(function (i, obj) {
		if ($(this).attr('id') !== 'trainercontainer') {
			const data: PageData = {
				menu: $(this).detach(),
				pages: [],
				maxPages: 0,
			};

			$(this).children().each(function (i, obj) {
				// send true state if it exists
				if ($(this).data('state') === 'ON') {
					const stateData: string[] = $(this).data('action').split(' ');
					sendData(stateData[0], { action: stateData[1], newstate: true });
				}

				const page = Math.floor(i / maxVisibleItems);

				if (data.pages[page] == null) {
					data.pages[page] = [];
				}

				data.pages[page].push($(this).detach());
				data.maxPages = page;
			});

			menus[$(this).attr("id")] = data;
		}
	});
}

function trainerUp(): void {
	$('.traineroption').eq(counter).attr('class', 'traineroption');

	if (counter > 1) {
		counter -= 1;
	} else {
		counter = maxPerPage;
	}

	$('.traineroption').eq(counter).attr('class', 'traineroption selected');
	playSound('NAV_UP_DOWN');
}

function trainerDown(): void {
	$('.traineroption').eq(counter).attr('class', 'traineroption');

	if (counter < maxPerPage) {
		counter += 1;
	} else {
		counter = 1;
	}

	$('.traineroption').eq(counter).attr('class', 'traineroption selected');
	playSound('NAV_UP_DOWN');
}

function trainerPrevPage(): void {
	let newPage: number;

	if (pageExists(currentPage - 1)) {
		newPage = currentPage - 1;
	} else {
		newPage = content.maxPages;
	}

	showPage(newPage);
	playSound('NAV_UP_DOWN');
}

function trainerNextPage(): void {
	let newPage: number;

	if (pageExists(currentPage + 1)) {
		newPage = currentPage + 1;
	} else {
		newPage = 0;
	}

	showPage(newPage);
	playSound('NAV_UP_DOWN');
}

function trainerBack(): void {
	if (content.menu == menus.mainmenu.menu) {
		container.hide();
		sendData('trainerclose', {});
	} else {
		showMenu(menus[content.menu.data('parent')]);
	}

	playSound('BACK');
}

function handleSelectedOption(): void {
	let item = $('.traineroption').eq(counter);

	if (item.data('sub')) {
		let submenu = menus[item.data('sub')];

		if (item.data('subdata')) {
			submenu.menu.attr('data-subdata', item.data('subdata'));
		} else {
			submenu.menu.attr('data-subdata', '');
		}

		showMenu(submenu);
	} else if (item.data('action')) {
		let newState: boolean = true;

		if (item.data('state')) {
			// .attr() because .data() gives original values
			if (item.attr('data-state') === 'ON') {
				newState = false;
				item.attr('data-state', 'OFF');
			} else if (item.attr('data-state') === 'OFF') {
				item.attr('data-state', 'ON');
			}
		}

		let data: string[] = item.data('action').split(' ');

		if (data[1] === '*') {
			data[1] = item.parent().attr('data-subdata');
		}

		if (data[0] === 'playerskin') {
			addToRecentSkins(data[1], item);
		}

		sendData(data[0], { action: data[1], newstate: newState });

	}

	playSound('SELECT');
}

function resetSelected(): void {
	$('.traineroption').each(function (i, obj) {
		if ($(this).attr('class') == 'traineroption selected') {
			$(this).attr('class', 'traineroption');
		}
	});

	counter = 1;
	maxPerPage = $('.traineroption').length - 1;
	$('.traineroption').eq(1).attr('class', 'traineroption selected');
}

function resetTrainer(): void {
	showMenu(menus.mainmenu);
}

function showMenu(menu): void {
	if (content != null) {
		content.menu.detach();
	}

	content = menu;
	container.append(content.menu);

	showPage(0);
}

function showPage(page: number): void {
	if (currentPage != null) {
		content.menu.children().detach();
	}

	currentPage = page;

	for (let i = 0; i < content.pages[currentPage].length; ++i) {
		content.menu.append(content.pages[currentPage][i]);
	}

	content.menu.append(pageIndicator);

	if (content.maxPages > 0) {
		$('#pageindicator').text(`Page ${currentPage + 1} / ${content.maxPages + 1}`);
	}

	resetSelected();
}

function pageExists(page: number): boolean {
	return content.pages[page] != null;
}

function sendData(name: string, data: any): JQueryXHR {
	return $.post(`http://${resourceName}/${name}`, JSON.stringify(data), function (response) {
		// console.log('Data response: ' + response);
	});
}

function playSound(sound: string): void {
	sendData('playsound', { name: sound });
}

function addToRecentSkins(skin: string, item: JQuery): boolean {
	// Remove this skin from the recent skins list
	recentSkins = recentSkins.filter(function (data) {
		return data[0] !== skin;
	});

	// Add this skin to the start
	recentSkins.unshift([skin, item]);

	// Clear the recent list
	menus.playerskinrecent.pages[0] = [];

	// Truncate the array to one page to save memory and bothering with pagination logic
	recentSkins.length = Math.min(recentSkins.length, maxVisibleItems);

	// Add a clone of each menu element to the recent menu
	$.each(recentSkins, function (id, ele) {
		menus.playerskinrecent.pages[0].push(ele[1].clone());
	});

	return true;
}
