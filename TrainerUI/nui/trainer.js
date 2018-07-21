/// <reference path="./js_refs/index.d.ts"/>
/// <reference path="./js_refs/jquery.d.ts"/>
/** CONFIG **/
// !! Change this to your current resource name !!
const resourceName = 'virakal-trainer';
// Max amount of items in 1 menu (before autopaging kicks in)
const maxVisibleItems = 12;
;
var counter;
var currentPage;
var menus = {};
var container;
var content;
var maxPerPage;
var pageIndicator = '<p id="pageindicator"></p>';
var imageContainer = $('<div id="imagecontainer">').hide();
var recentSkins = [];
$(function () {
    container = $('#trainercontainer');
    init();
    window.addEventListener('message', function (event) {
        let item = event.data;
        if (item.showtrainer) {
            resetTrainer();
            container.show();
            playSound('YES');
        }
        else if (item.hidetrainer) {
            container.hide();
            hideImageContainer();
            playSound('NO');
        }
        if (item.trainerenter) {
            handleSelectedOption();
        }
        else if (item.trainerback) {
            trainerBack();
        }
        if (item.trainerup) {
            trainerUp();
        }
        else if (item.trainerdown) {
            trainerDown();
        }
        if (item.trainerleft) {
            trainerPrevPage();
        }
        else if (item.trainerright) {
            trainerNextPage();
        }
        if (item.configupdate) {
            updateFromConfig(item.config);
        }
    });
});
function init() {
    $('div').each(function (i, obj) {
        if ($(this).attr('id') !== 'trainercontainer') {
            const data = {
                menu: $(this).detach(),
                pages: [],
                maxPages: 0,
            };
            $(this).children().each(function (i, obj) {
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
    imageContainer.appendTo('body');
}
function updateFromConfig(json) {
    const config = JSON.parse(json);
    // Hunt for menu items with config-key data set, then update them
    for (const menuName in menus) {
        let menuData = menus[menuName];
        for (const key in config) {
            menuData.pages.forEach(function (page) {
                page.forEach(function (trainerOption) {
                    const match = trainerOption.is(`.traineroption[data-state][data-config-key="${key}"]`);
                    if (match) {
                        let value = config[key];
                        if (value === "true") {
                            trainerOption.attr('data-state', 'ON');
                        }
                        else if (value === "false") {
                            trainerOption.attr('data-state', 'OFF');
                        }
                        else {
                            console.log(`Unexpected value for a config key: ${value}!`);
                        }
                    }
                });
            });
        }
    }
}
function trainerUp() {
    deselectItem($('.traineroption').eq(counter));
    if (counter > 1) {
        counter -= 1;
    }
    else {
        counter = maxPerPage;
    }
    selectItem($('.traineroption').eq(counter));
    playSound('NAV_UP_DOWN');
}
function trainerDown() {
    deselectItem($('.traineroption').eq(counter));
    if (counter < maxPerPage) {
        counter += 1;
    }
    else {
        counter = 1;
    }
    selectItem($('.traineroption').eq(counter));
    playSound('NAV_UP_DOWN');
}
function trainerPrevPage() {
    let newPage;
    if (pageExists(currentPage - 1)) {
        newPage = currentPage - 1;
    }
    else {
        newPage = content.maxPages;
    }
    showPage(newPage);
    playSound('NAV_UP_DOWN');
}
function selectItem(item) {
    item.addClass('selected');
    let imgSrc = item.data('image');
    if (imgSrc) {
        showImageContainer(imgSrc);
    }
    return item;
}
function deselectItem(item) {
    item.removeClass('selected');
    hideImageContainer();
    return item;
}
function showImageContainer(imgSrc) {
    let img = $('<img>')
        .attr('src', imgSrc);
    imageContainer.empty().append(img);
    imageContainer.show();
    return imageContainer;
}
function hideImageContainer() {
    imageContainer.hide();
    return imageContainer;
}
function trainerNextPage() {
    let newPage;
    if (pageExists(currentPage + 1)) {
        newPage = currentPage + 1;
    }
    else {
        newPage = 0;
    }
    showPage(newPage);
    playSound('NAV_UP_DOWN');
}
function trainerBack() {
    if (content.menu == menus.mainmenu.menu) {
        hideImageContainer();
        container.hide();
        sendData('trainerclose', {});
    }
    else {
        showMenu(menus[content.menu.data('parent')]);
    }
    playSound('BACK');
}
function handleSelectedOption() {
    let item = $('.traineroption').eq(counter);
    if (item.data('sub')) {
        let submenu = menus[item.data('sub')];
        if (item.data('subdata')) {
            submenu.menu.attr('data-subdata', item.data('subdata'));
        }
        else {
            submenu.menu.attr('data-subdata', '');
        }
        showMenu(submenu);
    }
    else if (item.data('action')) {
        let newState = true;
        if (item.data('state')) {
            // .attr() because .data() gives original values
            if (item.attr('data-state') === 'ON') {
                newState = false;
                item.attr('data-state', 'OFF');
            }
            else if (item.attr('data-state') === 'OFF') {
                item.attr('data-state', 'ON');
            }
        }
        let data = item.data('action').split(' ');
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
function resetSelected() {
    $('.traineroption').each(function (i, obj) {
        if ($(this).attr('class') == 'traineroption selected') {
            deselectItem($(this));
        }
    });
    counter = 1;
    maxPerPage = $('.traineroption').length - 1;
    selectItem($('.traineroption').eq(1));
}
function resetTrainer() {
    showMenu(menus.mainmenu);
}
function showMenu(menu) {
    if (content != null) {
        content.menu.detach();
    }
    content = menu;
    container.append(content.menu);
    showPage(0);
}
function showPage(page) {
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
function pageExists(page) {
    return content.pages[page] != null;
}
function sendData(name, data) {
    return $.post(`http://${resourceName}/${name}`, JSON.stringify(data), function (response) {
        // console.log('Data response: ' + response);
    });
}
function playSound(sound) {
    sendData('playsound', { name: sound });
}
function addToRecentSkins(skin, item) {
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
//# sourceMappingURL=trainer.js.map