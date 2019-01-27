<template>
    <div id="trainer-root">
        <div id="trainercontainer" v-if="showTrainer">
            <p class="traineroption trainertitle">{{ trainerTitle }}</p>
            <TrainerOption v-for="(item, index) in menuPage"
                           :class="{ selected: index == selected }"
                           :sub="item.sub"
                           :action="item.action"
                           :state="getItemState(item.action)"
                           :key="getItemKey(item)">
                {{ item.text }}
            </TrainerOption>
            <PageIndicator :page="page" :page-count="pageCount"></PageIndicator>
        </div>

        <PreviewImage :img="currentImage"></PreviewImage>
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import PreviewImage from './components/PreviewImage.vue';
    import TrainerOption from './components/TrainerOption.vue';
    import PageIndicator from './components/PageIndicator.vue';

    interface MenuItem {
        text: string,
        sub?: string,
        image?: string,
        state?: string,
        action?: string,
        configkey?: string,
        key?: string,
    }

    @Component({
        components: {
            PreviewImage,
            TrainerOption,
            PageIndicator,
        }
    })
    export default class Trainer extends Vue {
        trainerTitle = 'Virakal Trainer';
        resourceName = 'virakal-trainer';
        maxPageSize = 12;
        showTrainer = false;
        menus: any = { 'mainmenu': [{ text: "Waiting for menus to download..." }] };
        currentMenuKey = 'mainmenu';
        page = 0;
        selected = 0;
        recentSkins = []; // Don't think we need this
        configState: { [configKey: string]: boolean } = {};
        itemStates: { [action: string]: string } = {};
        configKeyActions: { [configKey: string]: string } = {};

        get pageCount(): number {
            return Math.ceil(this.menus[this.currentMenuKey].length / this.maxPageSize);
        };

        get menuPage(): MenuItem[] {
            return this.menus[this.currentMenuKey].slice(this.page * this.maxPageSize, (this.page + 1) * this.maxPageSize);
        };

        get currentItem(): MenuItem {
            const currentIndex = this.page * this.maxPageSize + this.selected;
            return this.menus[this.currentMenuKey][currentIndex];
        };

        get currentImage(): string {
            const currentIndex = this.page * this.maxPageSize + this.selected;
            return this.menus[this.currentMenuKey][currentIndex] ? this.menus[this.currentMenuKey][currentIndex].image : null;
        };

        get currentMenu(): MenuItem[] {
            return this.menus[this.currentMenuKey];
        };

        get parentKey(): string | undefined {
            // The main menu has no parent
            if (this.currentMenuKey === 'mainmenu') {
                return;
            }

            const lastDot = this.currentMenuKey.lastIndexOf('.');

            // A key without a dot is a top-level one, so the parent is the main menu
            if (lastDot === -1) {
                return 'mainmenu';
            }

            // Get the string up to the last dot, so a.b.c returns a.b
            return this.currentMenuKey.substring(0, lastDot);
        }

        created() {
            window.addEventListener("message", this.handleMessage, {
                passive: true,
            });
        }

        sendData(name: string, data: any): JQueryXHR {
            return $.post(`http://${this.resourceName}/${name}`, JSON.stringify(data), function (response) {
                // console.log('Data response: ' + response);
            });
        }

        playSound(sound: string): void {
            this.sendData('playsound', { name: sound });
        }

        showPage(page: number): void {
            this.page = page;
            this.selected = 0;
        }

        pageExists(page: number): boolean {
            return page >= 0 && page < this.pageCount;
        }

        nextPage(): void {
            if (this.pageExists(this.page + 1)) {
                this.showPage(this.page + 1);
            } else if (this.pageCount > 1) {
                this.showPage(0);
            }

            this.playSound('NAV_UP_DOWN');
        }

        previousPage(): void {
            if (this.pageExists(this.page - 1)) {
                this.showPage(this.page - 1);
            } else if (this.pageCount > 1) {
                this.showPage(this.pageCount - 1);
            }

            this.playSound('NAV_UP_DOWN');
        }

        selectUp(): void {
            this.selected = this.selected ? this.selected - 1 : this.menuPage.length - 1;
            this.playSound('NAV_UP_DOWN');
        }

        selectDown(): void {
            this.selected = (this.selected + 1) % this.menuPage.length;
            this.playSound('NAV_UP_DOWN');
        }

        resetTrainer(): void {
            this.showMenu('mainmenu');
        }

        setMenu(menuName: string, menuData: MenuItem[]): void {
            // console.log(`Receieved menu ${menuName}`);
            // console.log(JSON.stringify(menuData));

            // Grab any initial states that are included and update states on those we already have
            for (let key in menuData) {
                let item = menuData[key];

                if (item.state == null || item.action == null) {
                    continue;
                }

                if (item.configkey !== undefined && item.configkey !== '') {
                    if (item.configkey in this.configKeyActions) {
                        // Grab the config and override the itemState
                        let configState: boolean = this.configState[item.configkey];
                        let stateText = this.getStateText(configState);
                        console.log(`We know ${item.configkey} is ${this.configKeyActions[item.configkey]}. Setting itemStates[${item.action}] to ${stateText} (${configState})`);

                        this.itemStates[item.action] = stateText;
                        item.state = stateText;
                    } else {
                        // We don't know about this, so store it
                        console.log(`We don't know ${item.configkey} so we're storing ${item.action} in the configKeyActions map.`);
                        this.configKeyActions[item.configkey] = item.action;
                        this.configState[item.configkey] = item.state === 'ON';
                    }
                }

                if (key in this.itemStates) {
                    item.state = this.itemStates[item.action];
                } else {
                    this.itemStates[item.action] = item.state;
                }
            }

            // Update the menus list
            this.menus[menuName] = menuData;

            if (this.currentMenuKey === menuName) {
                // Because the underlying menu has changed, we need to force the update
                console.log('Forcing the update');
                this.updateCurrentMenu();
            }
        }

        // Only use this if the underlying structure for the current menu is changed. Vue doesn't seem to like that.
        updateCurrentMenu(): void {
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

        showMenu(menuName: string): void {
            if (!this.menus[menuName]) {
                console.log(`No such menu as '${menuName}'`);
                this.showMenu('mainmenu');
                return;
            }

            this.selected = 0;
            this.page = 0;
            this.currentMenuKey = menuName;
        }

        handleSelection(): void {
            const sel: MenuItem = this.currentItem;

            if (sel.sub) {
                this.showMenu(sel.sub);
            } else if (sel.action) {
                console.log(`Doing ${sel.action}`);
                let newState: boolean = true;

                if (sel.state) {
                    if (sel.state === 'ON') {
                        newState = false;
                        sel.state = 'OFF';
                    } else {
                        sel.state = 'ON';
                    }

                    this.itemStates[sel.action] = sel.state;
                }

                // Not sure why I need this, but state updates no longer pass to the main menu
                this.$forceUpdate();

                const data: string[] = sel.action.split(' ');

                console.log(`Sending ${data[0]}, action: ${data[1]}, newState: ${newState}`);
                this.sendData(data[0], { action: data[1], newstate: newState, itemtext: sel.text });
            }

            this.playSound('SELECT');
        }

        goBack(): void {
            if (typeof(this.parentKey) === 'undefined') {
                this.closeTrainer();
            } else {
                this.showMenu(this.parentKey);
            }

            this.playSound('BACK');
        }

        openTrainer(): void {
            this.resetTrainer();
            this.showTrainer = true;
            this.playSound('YES');
        }

        closeTrainer(): void {
            this.resetTrainer();
            this.showTrainer = false;
            this.sendData('trainerclose', {});
            this.playSound('NO');
        }

        updateFromConfig(json: string): void {
            const config: { [key: string]: string; } = JSON.parse(json);

            for (const key in config) {
                let value = config[key];

                if (value !== 'true' && value !== 'false') {
                    // We only care about boolean configs from a UI perspective
                    continue;
                }

                console.log(`Setting config[${key}] to ${value}.`);
                this.configState[key] = value === 'true';

                if (key in this.configKeyActions) {
                    let action = this.configKeyActions[key];
                    this.itemStates[action] = this.getStateText(value);
                }
            }

            this.$forceUpdate();
            console.log(`Item States: ${JSON.stringify(this.itemStates)}`);
        }


        getStateText(value: boolean | string): string {
            if (typeof (value) === 'string') {
                value = value === 'true';
            }

            return value ? 'ON' : 'OFF';
        }

        getItemKey(item: MenuItem): string {
            return item.key || item.text;
        }

        getItemState(action: string): string | undefined {
            return this.itemStates[action];
        }

        handleMessage(event: any): void {
            const item = event.data;

            if (item.showtrainer) {
                this.openTrainer();
            } else if (item.hidetrainer) {
                this.closeTrainer();
            }

            if (item.trainerenter) {
                this.handleSelection();
            } else if (item.trainerback) {
                this.goBack();
            }

            if (item.trainerleft) {
                this.previousPage();
            } else if (item.trainerright) {
                this.nextPage();
            }

            if (item.trainerup) {
                this.selectUp();
            } else if (item.trainerdown) {
                this.selectDown();
            }

            if (item.setmenu) {
                this.setMenu(item.menuname, item.menudata);
            }

            if (item.configupdate) {
                this.updateFromConfig(item.config);
            }
        }
    }
</script>

<style>
@font-face {
    font-family: "Roboto";
    src: url("assets/Roboto.ttf");
}

#trainercontainer {
    position: absolute;
    right: 200px;
    top: 100px;
}

p {
    font-family: "Roboto";
}
</style>
