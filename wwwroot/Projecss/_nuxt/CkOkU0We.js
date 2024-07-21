const __vite__fileDeps=["./DJmDCQjL.js","./bIp8vrNC.js","./entry.MN5E7vKX.css","./RouteMap.CsL6Qw8G.css"],__vite__mapDeps=i=>i.map(i=>__vite__fileDeps[i]);
import{_ as y,aJ as g,aQ as b,o as l,a as f,b as o,T as w,d as p,t as _,q as S,aR as E,i as D,l as N,u as R,W as x,F as V,e as F,p as Q,C as T,D as A,z as C}from"./bIp8vrNC.js";import{u as O}from"./CyCUcgYy.js";var m={kind:"Document",definitions:[{kind:"OperationDefinition",operation:"query",name:{kind:"Name",value:"EventDetailRoutesQuery"},variableDefinitions:[{kind:"VariableDefinition",variable:{kind:"Variable",name:{kind:"Name",value:"id"}},type:{kind:"NonNullType",type:{kind:"NamedType",name:{kind:"Name",value:"String"}}},directives:[]}],directives:[],selectionSet:{kind:"SelectionSet",selections:[{kind:"Field",alias:{kind:"Name",value:"event"},name:{kind:"Name",value:"Event"},arguments:[{kind:"Argument",name:{kind:"Name",value:"id"},value:{kind:"Variable",name:{kind:"Name",value:"id"}}}],directives:[],selectionSet:{kind:"SelectionSet",selections:[{kind:"Field",name:{kind:"Name",value:"id"},arguments:[],directives:[]},{kind:"Field",name:{kind:"Name",value:"routes"},arguments:[],directives:[]}]}}]}}],loc:{start:0,end:107}};m.loc.source={body:"query EventDetailRoutesQuery ($id: String!){\n    event: Event (id: $id) {\n        id\n        routes\n    }\n}",name:"GraphQL request",locationOffset:{line:1,column:1}};function u(e,t){if(e.kind==="FragmentSpread")t.add(e.name.value);else if(e.kind==="VariableDefinition"){var n=e.type;n.kind==="NamedType"&&t.add(n.name.value)}e.selectionSet&&e.selectionSet.selections.forEach(function(i){u(i,t)}),e.variableDefinitions&&e.variableDefinitions.forEach(function(i){u(i,t)}),e.definitions&&e.definitions.forEach(function(i){u(i,t)})}var v={};(function(){m.definitions.forEach(function(t){if(t.name){var n=new Set;u(t,n),v[t.name.value]=n}})})();function h(e,t){for(var n=0;n<e.definitions.length;n++){var i=e.definitions[n];if(i.name&&i.name.value==t)return i}}function M(e,t){var n={kind:e.kind,definitions:[h(e,t)]};e.hasOwnProperty("loc")&&(n.loc=e.loc);var i=v[t]||new Set,r=new Set,a=new Set;for(i.forEach(function(s){a.add(s)});a.size>0;){var c=a;a=new Set,c.forEach(function(s){if(!r.has(s)){r.add(s);var d=v[s]||new Set;d.forEach(function(k){a.add(k)})}})}return r.forEach(function(s){var d=h(e,s);d&&n.definitions.push(d)}),n}M(m,"EventDetailRoutesQuery");const $={name:"route",props:{item:{type:Object}},methods:{openMap(){g(b(()=>E(()=>import("./DJmDCQjL.js"),__vite__mapDeps([0,1,2,3]),import.meta.url)),{image:this.item.image})}}},q={class:"map-block"},B={class:"resize-image"},P=["src"],z={class:"event-map-buttons"},L={class:"row"},I={key:0,class:"col-lg-3 col-6 col-xxs-12"},j=["href"],G={class:"col-lg-3 col-6 col-xxs-12"},H=["href"];function J(e,t,n,i,r,a){return l(),f("div",q,[o("a",{onClick:t[0]||(t[0]=w((...c)=>a.openMap&&a.openMap(...c),["prevent"])),href:"",class:"modal-map-button"},[o("span",B,[o("img",{src:n.item.image.src,alt:""},null,8,P)])]),p(),o("div",z,[o("div",L,[n.item.route?(l(),f("div",I,[o("a",{href:n.item.route,download:"",target:"_blank",class:"btn btn-primary"},_(e.$t("events.routes.download"))+" gpx\n					",9,j)])):S("",!0),p(),o("div",G,[o("a",{href:"/local/tools/route.php?id="+n.item.id+"&pdf=Y",target:"_blank",class:"btn btn-primary"},_(e.$t("events.routes.download"))+" pdf\n					",9,H)])])])])}const W=y($,[["render",J]]),Y={class:"event-page__routes"},X={__name:"routes",async setup(e){let t,n;const{data:i,error:r}=([t,n]=D(async()=>O(async()=>await A(m,{id:C().params.id},"cache-first").then(({event:a})=>a.routes),"$VikDiurxSC")),t=await t,n(),t);if(r.value)throw N(r.value);return R({titleTemplate:x().t("events.tabs_seo.routes")+" %s"}),(a,c)=>(l(),f("div",Y,[(l(!0),f(V,null,F(Q(i),s=>(l(),T(W,{item:s,key:s.id},null,8,["item"]))),128))]))}};export{X as default};