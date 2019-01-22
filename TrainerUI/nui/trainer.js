/// <reference path="./js_refs/index.d.ts" />
/// <reference path="./js_refs/jquery.d.ts" />
//// <reference path="./node_modules/vue/types/vue.d.ts" />
/** The name of the resource on the server */
const resourceName = 'virakal-trainer';
/** The maximum number of items on a page */
const maxPageSize = 12;
/** Text to show in the title bar */
const trainerTitle = 'Virakal Trainer';
function sendData(name, data) {
    return $.post(`http://${resourceName}/${name}`, JSON.stringify(data), function (response) {
        // console.log('Data response: ' + response);
    });
}
function playSound(sound) {
    sendData('playsound', { name: sound });
}
function showPage(page) {
    this.page = page;
    this.selected = 0;
}
function pageExists(page) {
    return page >= 0 && page <= this.pageCount;
}
function nextPage() {
    if (this.pageExists(this.page + 1)) {
        this.showPage(this.page + 1);
    }
    else {
        this.showPage(0);
    }
    playSound('NAV_UP_DOWN');
}
function previousPage() {
    if (this.pageExists(this.page - 1)) {
        this.showPage(this.page - 1);
    }
    else {
        this.showPage(this.pageCount - 1);
    }
    playSound('NAV_UP_DOWN');
}
function selectUp() {
    this.selected = this.selected ? this.selected - 1 : this.menuPage.length - 1;
    playSound('NAV_UP_DOWN');
}
function selectDown() {
    this.selected = (this.selected + 1) % this.menuPage.length;
    playSound('NAV_UP_DOWN');
}
function resetTrainer() {
    this.showMenu('mainmenu');
}
function setMenu(menuName, menuData) {
    console.log(`Receieved menu ${menuName}: ${JSON.stringify(menuData)}`);
    this.menus[menuName] = menuData;
}
function showMenu(menuName) {
    if (this.menus[menuName]) {
        this.selected = 0;
        this.page = 0;
        this.currentMenu = this.menus[menuName];
    }
    else {
        console.log(`No such menu as '${menuName}'`);
        this.showMenu('mainmenu');
    }
}
function handleSelection() {
    let sel = this.currentItem;
    if (sel.sub) {
        this.showMenu(sel.sub);
    }
    else if (sel.action) {
        console.log(`Would do ${sel.action}`);
        let newState = true;
        if (sel.state) {
            if (sel.state === "ON") {
                newState = false;
                sel.state = "OFF";
            }
            else {
                sel.state = "ON";
            }
        }
        let data = sel.action.split(' ');
        if (data[1] === '*') {
            console.log("Subdata not implemented");
            // data[1] = item.parent().attr('data-subdata');
        }
        if (data[0] === 'playerskin') {
            console.log("Recent skins not yet implemented");
            // addToRecentSkins(data[1], item);
        }
        sendData(data[0], { action: data[1], newstate: newState, itemtext: sel.text });
    }
    playSound('SELECT');
}
function goBack() {
    let sel = this.currentItem;
    if (sel.parent) {
        this.showMenu(sel.parent);
    }
    else {
        this.closeTrainer();
    }
    playSound('BACK');
}
function openTrainer() {
    this.resetTrainer();
    this.showTrainer = true;
    playSound('YES');
}
function closeTrainer() {
    this.showTrainer = false;
    sendData('trainerclose', {});
    playSound('NO');
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
/**
 * The floating preview image that shows cars, etc.
 */
Vue.component('preview-image', {
    props: ['img'],
    template: '<div id="imagecontainer" v-if="img"><img :src="img"></div>',
});
let menus = {
    mainmenu: [ /* Loading placeholder */],
};
let app = new Vue({
    el: '#vuecontainer',
    data: {
        trainerTitle,
        maxPageSize,
        showTrainer: false,
        menus: menus,
        currentMenu: menus.mainmenu,
        page: 0,
        selected: 0,
        recentSkins: [],
        configState: {},
    },
    computed: {
        pageCount: function () {
            return Math.floor((this.currentMenu.length - 1) / this.maxPageSize);
        },
        menuPage: function () {
            return this.currentMenu.slice(this.page * this.maxPageSize, (this.page + 1) * this.maxPageSize);
        },
        currentIndex: function () {
            return this.page * this.maxPageSize + this.selected;
        },
        currentItem: function () {
            return this.currentMenu[this.currentIndex];
        },
        currentImage: function () {
            return this.currentItem ? this.currentItem.image : null;
        },
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
    },
});
window.addEventListener('message', function (event) {
    let item = event.data;
    if (item.showtrainer) {
        app.openTrainer();
    }
    else if (item.hidetrainer) {
        app.closeTrainer();
    }
    if (item.trainerenter) {
        app.handleSelection();
    }
    else if (item.trainerback) {
        app.goBack();
    }
    if (item.trainerleft) {
        app.previousPage();
    }
    else if (item.trainerright) {
        app.nextPage();
    }
    if (item.trainerup) {
        app.selectUp();
    }
    else if (item.trainerdown) {
        app.selectDown();
    }
    if (item.setmenu) {
        app.setMenu(item.menuname, item.menudata);
    }
});
//# sourceMappingURL=trainer.js.map