(function(e){function t(t){for(var i,r,o=t[0],c=t[1],u=t[2],l=0,g=[];l<o.length;l++)r=o[l],s[r]&&g.push(s[r][0]),s[r]=0;for(i in c)Object.prototype.hasOwnProperty.call(c,i)&&(e[i]=c[i]);h&&h(t);while(g.length)g.shift()();return a.push.apply(a,u||[]),n()}function n(){for(var e,t=0;t<a.length;t++){for(var n=a[t],i=!0,o=1;o<n.length;o++){var c=n[o];0!==s[c]&&(i=!1)}i&&(a.splice(t--,1),e=r(r.s=n[0]))}return e}var i={},s={app:0},a=[];function r(t){if(i[t])return i[t].exports;var n=i[t]={i:t,l:!1,exports:{}};return e[t].call(n.exports,n,n.exports,r),n.l=!0,n.exports}r.m=e,r.c=i,r.d=function(e,t,n){r.o(e,t)||Object.defineProperty(e,t,{enumerable:!0,get:n})},r.r=function(e){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},r.t=function(e,t){if(1&t&&(e=r(e)),8&t)return e;if(4&t&&"object"===typeof e&&e&&e.__esModule)return e;var n=Object.create(null);if(r.r(n),Object.defineProperty(n,"default",{enumerable:!0,value:e}),2&t&&"string"!=typeof e)for(var i in e)r.d(n,i,function(t){return e[t]}.bind(null,i));return n},r.n=function(e){var t=e&&e.__esModule?function(){return e["default"]}:function(){return e};return r.d(t,"a",t),t},r.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)},r.p="";var o=window["webpackJsonp"]=window["webpackJsonp"]||[],c=o.push.bind(o);o.push=t,o=o.slice();for(var u=0;u<o.length;u++)t(o[u]);var h=c;a.push([0,"chunk-vendors"]),n()})({0:function(e,t,n){e.exports=n("f684")},2278:function(e,t,n){"use strict";var i=n("955e"),s=n.n(i);s.a},"490b":function(e,t,n){"use strict";var i=n("7bc5"),s=n.n(i);s.a},"7bc5":function(e,t,n){},"955e":function(e,t,n){},abf6:function(e,t,n){"use strict";var i=n("cde2"),s=n.n(i);s.a},cde2:function(e,t,n){},f684:function(e,t,n){"use strict";n.r(t);n("0d38");var i=n("af75"),s=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{attrs:{id:"trainer-root"}},[e.showTrainer?n("div",{attrs:{id:"trainercontainer"}},[n("p",{staticClass:"traineroption trainertitle"},[e._v(e._s(e.trainerTitle))]),e._l(e.menuPage,function(t,i){return n("TrainerOption",{key:e.getItemKey(t),class:{selected:i==e.selected,sub:null!=t.sub},attrs:{sub:t.sub,action:t.action,state:e.getItemState(t.action)}},[e._v("\n            "+e._s(t.text)+"\n        ")])}),n("PageIndicator",{attrs:{page:e.page,"page-count":e.pageCount}})],2):e._e(),n("PreviewImage",{attrs:{img:e.currentImage}})],1)},a=[],r=n("69e1"),o=n.n(r),c=n("d8df"),u=n("523d"),h=function(){var e=this,t=e.$createElement,n=e._self._c||t;return e.img?n("div",{staticClass:"imagecontainer"},[n("img",{attrs:{src:e.img}})]):e._e()},l=[];let g=class extends u["c"]{};c["a"]([Object(u["b"])()],g.prototype,"img",void 0),g=c["a"]([u["a"]],g);var p=g,d=p,f=(n("2278"),n("a56e")),m=Object(f["a"])(d,h,l,!1,null,"1e72d9b8",null),y=m.exports,b=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("p",{staticClass:"traineroption",attrs:{"data-state":e.state}},[e._t("default")],2)},v=[];let S=class extends u["c"]{};c["a"]([Object(u["b"])()],S.prototype,"text",void 0),c["a"]([Object(u["b"])()],S.prototype,"sub",void 0),c["a"]([Object(u["b"])()],S.prototype,"action",void 0),c["a"]([Object(u["b"])()],S.prototype,"state",void 0),c["a"]([Object(u["b"])()],S.prototype,"image",void 0),S=c["a"]([u["a"]],S);var w=S,O=w,x=Object(f["a"])(O,b,v,!1,null,"ca6195a6",null),P=x.exports,M=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("p",{staticClass:"pageindicator"},[e._v("Page "+e._s(e.page+1)+" of "+e._s(e.pageCount))])},_=[];let K=class extends u["c"]{};c["a"]([Object(u["b"])()],K.prototype,"page",void 0),c["a"]([Object(u["b"])()],K.prototype,"pageCount",void 0),K=c["a"]([u["a"]],K);var T=K,k=T,j=(n("abf6"),Object(f["a"])(k,M,_,!1,null,"415de485",null)),C=j.exports;let N=class extends u["c"]{constructor(){super(...arguments),this.trainerTitle="Virakal Trainer",this.resourceName="virakal-trainer",this.maxPageSize=12,this.showTrainer=!1,this.menus={mainmenu:[{text:"Waiting for menus to download..."}]},this.currentMenuKey="mainmenu",this.page=0,this.selected=0,this.recentSkins=[],this.configState={},this.itemStates={},this.configKeyActions={}}get pageCount(){return Math.ceil(this.menus[this.currentMenuKey].length/this.maxPageSize)}get menuPage(){return this.menus[this.currentMenuKey].slice(this.page*this.maxPageSize,(this.page+1)*this.maxPageSize)}get currentItem(){const e=this.page*this.maxPageSize+this.selected;return this.menus[this.currentMenuKey][e]}get currentImage(){const e=this.page*this.maxPageSize+this.selected;return this.menus[this.currentMenuKey][e]?this.menus[this.currentMenuKey][e].image:null}get currentMenu(){return this.menus[this.currentMenuKey]}get parentKey(){if("mainmenu"===this.currentMenuKey)return;const e=this.currentMenuKey.lastIndexOf(".");return-1===e?"mainmenu":this.currentMenuKey.substring(0,e)}created(){window.addEventListener("message",this.handleMessage,{passive:!0})}sendData(e,t){return $.post(`http://${this.resourceName}/${e}`,o()(t),function(e){})}playSound(e){this.sendData("playsound",{name:e})}showPage(e){this.page=e,this.selected=0}pageExists(e){return e>=0&&e<this.pageCount}nextPage(){this.pageExists(this.page+1)?this.showPage(this.page+1):this.pageCount>1&&this.showPage(0),this.playSound("NAV_UP_DOWN")}previousPage(){this.pageExists(this.page-1)?this.showPage(this.page-1):this.pageCount>1&&this.showPage(this.pageCount-1),this.playSound("NAV_UP_DOWN")}selectUp(){this.selected=this.selected?this.selected-1:this.menuPage.length-1,this.playSound("NAV_UP_DOWN")}selectDown(){this.selected=(this.selected+1)%this.menuPage.length,this.playSound("NAV_UP_DOWN")}resetTrainer(){this.showMenu("mainmenu")}setMenu(e,t){for(let n in t){let e=t[n];if(null!=e.state&&null!=e.action){if(void 0!==e.configkey&&""!==e.configkey)if(e.configkey in this.configKeyActions){let t=this.configState[e.configkey],n=this.getStateText(t);console.log(`We know ${e.configkey} is ${this.configKeyActions[e.configkey]}. Setting itemStates[${e.action}] to ${n} (${t})`),this.itemStates[e.action]=n,e.state=n}else console.log(`We don't know ${e.configkey} so we're storing ${e.action} in the configKeyActions map.`),this.configKeyActions[e.configkey]=e.action,this.configState[e.configkey]="ON"===e.state;n in this.itemStates?e.state=this.itemStates[e.action]:this.itemStates[e.action]=e.state}}this.menus[e]=t,this.currentMenuKey===e&&(console.log("Forcing the update"),this.updateCurrentMenu())}updateCurrentMenu(){const e=this.currentMenuKey;this.currentMenuKey="mainmenu",this.$forceUpdate(),this.currentMenuKey=e,this.selected>=this.currentMenu.length&&(this.page=0,this.selected=0)}showMenu(e){if(!this.menus[e])return console.log(`No such menu as '${e}'`),void this.showMenu("mainmenu");this.selected=0,this.page=0,this.currentMenuKey=e}handleSelection(){const e=this.currentItem;if(e.sub)this.showMenu(e.sub);else if(e.action){console.log(`Doing ${e.action}`);let t=!0;e.state&&("ON"===e.state?(t=!1,e.state="OFF"):e.state="ON",this.itemStates[e.action]=e.state),this.$forceUpdate();const n=e.action.split(" ");console.log(`Sending ${n[0]}, action: ${n[1]}, newState: ${t}`),this.sendData(n[0],{action:n[1],newstate:t,itemtext:e.text})}this.playSound("SELECT")}goBack(){"undefined"===typeof this.parentKey?this.closeTrainer():this.showMenu(this.parentKey),this.playSound("BACK")}openTrainer(){this.resetTrainer(),this.showTrainer=!0,this.playSound("YES")}closeTrainer(){this.resetTrainer(),this.showTrainer=!1,this.sendData("trainerclose",{}),this.playSound("NO")}updateFromConfig(e){const t=JSON.parse(e);for(const n in t){let e=t[n];if(("true"===e||"false"===e)&&(console.log(`Setting config[${n}] to ${e}.`),this.configState[n]="true"===e,n in this.configKeyActions)){let t=this.configKeyActions[n];this.itemStates[t]=this.getStateText(e)}}this.$forceUpdate(),console.log(`Item States: ${o()(this.itemStates)}`)}getStateText(e){return"string"===typeof e&&(e="true"===e),e?"ON":"OFF"}getItemKey(e){return e.key||e.text}getItemState(e){return this.itemStates[e]}handleMessage(e){const t=e.data;t.showtrainer?this.openTrainer():t.hidetrainer&&this.closeTrainer(),t.trainerenter?this.handleSelection():t.trainerback&&this.goBack(),t.trainerleft?this.previousPage():t.trainerright&&this.nextPage(),t.trainerup?this.selectUp():t.trainerdown&&this.selectDown(),t.setmenu&&this.setMenu(t.menuname,t.menudata),t.configupdate&&this.updateFromConfig(t.config)}};N=c["a"]([Object(u["a"])({components:{PreviewImage:y,TrainerOption:P,PageIndicator:C}})],N);var I=N,A=I,D=(n("490b"),Object(f["a"])(A,s,a,!1,null,null,null)),E=D.exports;i["default"].config.productionTip=!0,new i["default"]({render:e=>e(E)}).$mount("#app")}});
//# sourceMappingURL=app.js.map