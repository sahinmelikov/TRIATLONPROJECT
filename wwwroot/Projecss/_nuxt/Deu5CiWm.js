import{a as l}from"./X7eZhn6A.js";import{_ as s}from"./BfWe1yh-.js";import{A as r,o as t,a as n,q as a,d as i,b as c,t as m,f as d}from"./bIp8vrNC.js";import"./YU89knj8.js";import"./BvQgWdB0.js";import"./z1mF-5nA.js";const v={class:"event-page__main"},u=["innerHTML"],y={key:1,class:"article-image"},h=["src","alt","title"],g=["innerHTML"],f={key:3,class:"competition-type-wrap competition-types-block"},H={__name:"index",props:{event:Object},setup(e){return r(()=>{l()}),(o,k)=>(t(),n("div",v,[e.event.preview.length?(t(),n("div",{key:0,class:"article-announce article-content",innerHTML:e.event.preview},null,8,u)):a("",!0),i(),e.event.image?(t(),n("div",y,[c("img",{src:e.event.image,alt:e.event.title,title:e.event.title},null,8,h)])):a("",!0),i(),e.event.text.length?(t(),n("article",{key:2,class:"article-content",innerHTML:e.event.text},null,8,g)):a("",!0),i(),e.event.type?(t(),n("div",f,[c("h2",null,m(o.$t("events.about_type")),1),i(),d(s,{type:e.event.type},null,8,["type"])])):a("",!0)]))}};export{H as default};