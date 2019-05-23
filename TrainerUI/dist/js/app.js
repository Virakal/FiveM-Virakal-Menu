(function(e){function t(t){for(var i,a,o=t[0],u=t[1],c=t[2],l=0,g=[];l<o.length;l++)a=o[l],s[a]&&g.push(s[a][0]),s[a]=0;for(i in u)Object.prototype.hasOwnProperty.call(u,i)&&(e[i]=u[i]);h&&h(t);while(g.length)g.shift()();return r.push.apply(r,c||[]),n()}function n(){for(var e,t=0;t<r.length;t++){for(var n=r[t],i=!0,o=1;o<n.length;o++){var u=n[o];0!==s[u]&&(i=!1)}i&&(r.splice(t--,1),e=a(a.s=n[0]))}return e}var i={},s={app:0},r=[];function a(t){if(i[t])return i[t].exports;var n=i[t]={i:t,l:!1,exports:{}};return e[t].call(n.exports,n,n.exports,a),n.l=!0,n.exports}a.m=e,a.c=i,a.d=function(e,t,n){a.o(e,t)||Object.defineProperty(e,t,{enumerable:!0,get:n})},a.r=function(e){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},a.t=function(e,t){if(1&t&&(e=a(e)),8&t)return e;if(4&t&&"object"===typeof e&&e&&e.__esModule)return e;var n=Object.create(null);if(a.r(n),Object.defineProperty(n,"default",{enumerable:!0,value:e}),2&t&&"string"!=typeof e)for(var i in e)a.d(n,i,function(t){return e[t]}.bind(null,i));return n},a.n=function(e){var t=e&&e.__esModule?function(){return e["default"]}:function(){return e};return a.d(t,"a",t),t},a.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)},a.p="";var o=window["webpackJsonp"]=window["webpackJsonp"]||[],u=o.push.bind(o);o.push=t,o=o.slice();for(var c=0;c<o.length;c++)t(o[c]);var h=u;r.push([0,"chunk-vendors"]),n()})({0:function(e,t,n){e.exports=n("f684")},"490b":function(e,t,n){"use strict";var i=n("7bc5"),s=n.n(i);s.a},"7bc5":function(e,t,n){},"82fc":function(e,t,n){},abf6:function(e,t,n){"use strict";var i=n("cde2"),s=n.n(i);s.a},cde2:function(e,t,n){},e553:function(e,t,n){"use strict";var i=n("82fc"),s=n.n(i);s.a},f684:function(e,t,n){"use strict";n.r(t);var i=n("af75"),s=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{attrs:{id:"trainer-root"}},[e.showTrainer?n("div",{attrs:{id:"trainercontainer"}},[n("p",{staticClass:"traineroption trainertitle"},[e._v(e._s(e.trainerTitle))]),e._l(e.menuPage,function(t,i){return n("p",{key:e.getItemKey(t),class:{traineroption:!0,selected:i==e.selected,sub:null!=t.sub},attrs:{sub:t.sub,action:t.action,"data-state":e.getItemStateString(t.action)}},[e._v("\n            "+e._s(t.text)+"\n        ")])}),n("PageIndicator",{attrs:{page:e.page,"page-count":e.pageCount}})],2):e._e(),n("PreviewImage",{attrs:{img:e.currentImage}})],1)},r=[],a=n("d8df"),o=n("523d"),u=function(){var e=this,t=e.$createElement,n=e._self._c||t;return e.img?n("div",{staticClass:"imagecontainer"},[n("img",{attrs:{src:e.img}})]):e._e()},c=[];let h=class extends o["c"]{};a["a"]([Object(o["b"])()],h.prototype,"img",void 0),h=a["a"]([o["a"]],h);var l=h,g=l,p=(n("e553"),n("a56e")),d=Object(p["a"])(g,u,c,!1,null,"3b4a3a18",null),f=d.exports,m=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("p",{staticClass:"pageindicator"},[e._v("Page "+e._s(e.page+1)+" of "+e._s(e.pageCount))])},y=[];let v=class extends o["c"]{};a["a"]([Object(o["b"])()],v.prototype,"page",void 0),a["a"]([Object(o["b"])()],v.prototype,"pageCount",void 0),v=a["a"]([o["a"]],v);var S=v,b=S,w=(n("abf6"),Object(p["a"])(b,m,y,!1,null,"415de485",null)),P=w.exports;let M=class extends o["c"]{constructor(){super(...arguments),this.trainerTitle="Virakal Trainer",this.resourceName="virakal-trainer",this.maxPageSize=15,this.showTrainer=!1,this.menus={mainmenu:[{text:"Waiting for menus to download..."}]},this.currentMenuKey="mainmenu",this.page=0,this.selected=0,this.config={},this.itemStates={}}get pageCount(){return Math.ceil(this.menus[this.currentMenuKey].length/this.maxPageSize)}get menuPage(){return this.menus[this.currentMenuKey].slice(this.page*this.maxPageSize,(this.page+1)*this.maxPageSize)}get currentItem(){const e=this.page*this.maxPageSize+this.selected;return this.menus[this.currentMenuKey][e]}get currentImage(){const e=this.page*this.maxPageSize+this.selected;return this.menus[this.currentMenuKey][e]?this.menus[this.currentMenuKey][e].image:void 0}get currentMenu(){return this.menus[this.currentMenuKey]}get parentKey(){if("mainmenu"===this.currentMenuKey)return;const e=this.currentMenuKey.lastIndexOf(".");return-1===e?"mainmenu":this.currentMenuKey.substring(0,e)}created(){window.addEventListener("message",this.handleMessage,{passive:!0})}sendData(e,t={}){return $.post(`http://${this.resourceName}/${e}`,JSON.stringify(t),function(e){})}playSound(e){this.sendData("playsound",{name:e})}showPage(e){this.page=e,this.selected=0}pageExists(e){return e>=0&&e<this.pageCount}nextPage(){this.pageExists(this.page+1)?this.showPage(this.page+1):this.pageCount>1&&this.showPage(0),this.playSound("NAV_UP_DOWN")}previousPage(){this.pageExists(this.page-1)?this.showPage(this.page-1):this.pageCount>1&&this.showPage(this.pageCount-1),this.playSound("NAV_UP_DOWN")}selectUp(){this.selected=this.selected?this.selected-1:this.menuPage.length-1,this.playSound("NAV_UP_DOWN")}selectDown(){this.selected=(this.selected+1)%this.menuPage.length,this.playSound("NAV_UP_DOWN")}resetTrainer(){this.showMenu("mainmenu")}setMenu(e,t){for(let n in t){let e=t[n];null!=e.state&&null!=e.action&&(e.action in this.itemStates?e.state=this.getStateText(this.itemStates[e.action]):null!=e.configkey&&e.configkey in this.config&&(this.itemStates[e.action]=this.config[e.configkey],e.state=this.getStateText(this.config[e.configkey])),t[n]=e)}this.menus[e]=t,this.currentMenuKey===e&&this.updateCurrentMenu()}updateCurrentMenu(){const e=this.currentMenuKey;this.currentMenuKey="mainmenu",this.$forceUpdate(),this.currentMenuKey=e,this.selected>=this.currentMenu.length&&(this.page=0,this.selected=0)}showMenu(e){if(!this.menus[e])return console.log(`No such menu as '${e}'`),void this.showMenu("mainmenu");this.selected=0,this.page=0,this.currentMenuKey=e}handleSelection(){const e=this.currentItem;if(e.sub)this.showMenu(e.sub);else if(e.action){let t=!0;e.action in this.itemStates&&(t=!this.itemStates[e.action],this.itemStates[e.action]=t,this.$forceUpdate());const n=e.action.split(" ");console.log(`Sending message to server: ${n[0]}, action: ${n[1]}, newState: ${t}`),this.sendData(n[0],{action:n[1],newstate:t,itemtext:e.text})}this.playSound("SELECT")}goBack(){"undefined"===typeof this.parentKey?this.closeTrainer():this.showMenu(this.parentKey),this.playSound("BACK")}openTrainer(){this.resetTrainer(),this.showTrainer=!0,this.playSound("YES")}closeTrainer(){this.resetTrainer(),this.showTrainer=!1,this.sendData("trainerclose"),this.playSound("NO")}updateFromConfig(e){const t=JSON.parse(e);for(const n in t){let e=t[n];"true"!==e&&"false"!==e||(this.config[n]="true"===e)}}getStateText(e){return"string"===typeof e&&(e="true"===e),e?"ON":"OFF"}getItemKey(e){return e.key||e.action||e.text}getItemStateString(e){if(e in this.itemStates)return this.itemStates[e]?"ON":"OFF"}handleMessage(e){const t=e.data;t.showtrainer?this.openTrainer():t.hidetrainer&&this.closeTrainer(),t.trainerenter?this.handleSelection():t.trainerback&&this.goBack(),t.trainerleft?this.previousPage():t.trainerright&&this.nextPage(),t.trainerup?this.selectUp():t.trainerdown&&this.selectDown(),t.setmenu&&this.setMenu(t.menuname,t.menudata),t.configupdate&&this.updateFromConfig(t.config)}};M=a["a"]([Object(o["a"])({components:{PreviewImage:f,PageIndicator:P}})],M);var x=M,_=x,O=(n("490b"),Object(p["a"])(_,s,r,!1,null,null,null)),T=O.exports;i["default"].config.productionTip=!0,new i["default"]({render:e=>e(T)}).$mount("#app")}});
//# sourceMappingURL=app.js.map