var resourceName = 'virakal-trainer';
var maxPageSize = 12;
var trainerTitle = 'Virakal Trainer';
function sendData(name, data) {
    return $.post("http://" + resourceName + "/" + name, JSON.stringify(data), function (response) {
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
    return page >= 0 && page < this.pageCount;
}
function nextPage() {
    console.log("Current: " + this.page + " Next: " + (this.page + 1) + " PageCount: " + this.pageCount + " NextExists: " + this.pageExists(this.page + 1));
    if (this.pageExists(this.page + 1)) {
        this.showPage(this.page + 1);
    }
    else if (this.pageCount > 1) {
        this.showPage(0);
    }
    playSound('NAV_UP_DOWN');
}
function previousPage() {
    console.log("Current: " + this.page + " Prev: " + (this.page - 1) + " PageCount: " + this.pageCount + " PrevExists: " + this.pageExists(this.page - 1));
    if (this.pageExists(this.page - 1)) {
        this.showPage(this.page - 1);
    }
    else if (this.pageCount > 1) {
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
    console.log("Receieved menu " + menuName);
    this.menus[menuName] = menuData;
    if (this.currentMenuKey === menuName) {
        console.log("Forcing the update");
        this.updateCurrentMenu();
    }
}
function updateCurrentMenu() {
    var newMenuKey = this.currentMenuKey;
    this.currentMenuKey = 'mainmenu';
    this.$forceUpdate();
    this.currentMenuKey = newMenuKey;
    if (this.selected >= this.currentMenu.length) {
        this.page = 0;
        this.selected = 0;
    }
}
function showMenu(menuName) {
    if (!this.menus[menuName]) {
        console.log("No such menu as '" + menuName + "'");
        this.showMenu('mainmenu');
        return;
    }
    this.selected = 0;
    this.page = 0;
    this.currentMenuKey = menuName;
}
function handleSelection() {
    var sel = this.currentItem;
    if (sel.sub) {
        this.showMenu(sel.sub);
    }
    else if (sel.action) {
        console.log("Doing " + sel.action);
        var newState = true;
        if (sel.state) {
            if (sel.state === "ON") {
                newState = false;
                sel.state = "OFF";
            }
            else {
                sel.state = "ON";
            }
        }
        this.$forceUpdate();
        var data = sel.action.split(' ');
        if (data[1] === '*') {
            console.log("Subdata not implemented");
        }
        if (data[0] === 'playerskin') {
            console.log("Recent skins not yet implemented");
        }
        console.log("Sending " + data[0] + ", action: " + data[1] + ", newState: " + newState);
        sendData(data[0], { action: data[1], newstate: newState, itemtext: sel.text });
    }
    playSound('SELECT');
}
function goBack() {
    if (this.parentKey) {
        this.showMenu(this.parentKey);
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
    this.resetTrainer();
    this.showTrainer = false;
    sendData('trainerclose', {});
    playSound('NO');
}
function updateFromConfig(json) {
    console.log("Not yet implemented");
    var config = JSON.parse(json);
    for (var key in config) {
        var value = config[key];
        this.configState[key] = value;
    }
}
function getStateFromConfig(configKey) {
    return this.configState[configKey];
}
function getStateText(configKey) {
    return this.getStateFromConfig(configKey) ? 'ON' : 'OFF';
}
function getItemKey(item) {
    return item.key || item.text;
}
Vue.component('trainer-option', {
    props: ['text', 'sub', 'action', 'state', 'image'],
    template: '<p class="traineroption" :data-sub="sub" :data-action="action" :data-state="state" :data-image="image"><slot></slot></p>'
});
Vue.component('page-indicator', {
    props: ['page', 'pageCount'],
    template: '<p id="pageindicator">Page {{ page + 1 }} / {{ pageCount }}</p>'
});
Vue.component('preview-image', {
    props: ['img'],
    template: '<div id="imagecontainer" v-if="img"><img :src="img"></div>'
});
var menus = {
    mainmenu: []
};
var app = new Vue({
    el: '#vuecontainer',
    data: {
        trainerTitle: trainerTitle,
        maxPageSize: maxPageSize,
        showTrainer: false,
        menus: menus,
        currentMenuKey: 'mainmenu',
        page: 0,
        selected: 0,
        recentSkins: [],
        configState: {}
    },
    computed: {
        pageCount: function () {
            return 1 + Math.floor(this.menus[this.currentMenuKey].length / this.maxPageSize);
        },
        menuPage: function () {
            return this.menus[this.currentMenuKey].slice(this.page * this.maxPageSize, (this.page + 1) * this.maxPageSize);
        },
        currentItem: function () {
            var currentIndex = this.page * this.maxPageSize + this.selected;
            return this.menus[this.currentMenuKey][currentIndex];
        },
        currentImage: function () {
            var currentIndex = this.page * this.maxPageSize + this.selected;
            return this.menus[this.currentMenuKey][currentIndex] ? this.menus[this.currentMenuKey][currentIndex].image : null;
        },
        currentMenu: function () {
            return this.menus[this.currentMenuKey];
        },
        parentKey: function () {
            if (this.currentMenuKey === "mainmenu") {
                return false;
            }
            var lastDot = this.currentMenuKey.lastIndexOf(".");
            if (lastDot === -1) {
                return "mainmenu";
            }
            return this.currentMenuKey.substring(0, lastDot);
        }
    },
    methods: {
        showPage: showPage,
        nextPage: nextPage,
        previousPage: previousPage,
        pageExists: pageExists,
        selectUp: selectUp,
        selectDown: selectDown,
        resetTrainer: resetTrainer,
        setMenu: setMenu,
        showMenu: showMenu,
        handleSelection: handleSelection,
        goBack: goBack,
        openTrainer: openTrainer,
        closeTrainer: closeTrainer,
        updateFromConfig: updateFromConfig,
        getStateFromConfig: getStateFromConfig,
        getStateText: getStateText,
        getItemKey: getItemKey,
        updateCurrentMenu: updateCurrentMenu
    }
});
window.addEventListener('message', function (event) {
    var item = event.data;
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