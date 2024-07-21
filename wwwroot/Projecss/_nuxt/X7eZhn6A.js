import{g as E,i as y,d as P,f as v,h as I,S as g,N as C}from"./YU89knj8.js";function O(u){let{swiper:e,extendParams:i,on:o}=u;i({thumbs:{swiper:null,multipleActiveThumbs:!0,autoScrollOffset:0,slideThumbActiveClass:"swiper-slide-thumb-active",thumbsContainerClass:"swiper-thumbs"}});let h=!1,w=!1;e.thumbs={swiper:null};function p(){const s=e.thumbs.swiper;if(!s||s.destroyed)return;const t=s.clickedIndex,r=s.clickedSlide;if(r&&r.classList.contains(e.params.thumbs.slideThumbActiveClass)||typeof t>"u"||t===null)return;let n;s.params.loop?n=parseInt(s.clickedSlide.getAttribute("data-swiper-slide-index"),10):n=t,e.params.loop?e.slideToLoop(n):e.slideTo(n)}function l(){const{thumbs:s}=e.params;if(h)return!1;h=!0;const t=e.constructor;if(s.swiper instanceof t)e.thumbs.swiper=s.swiper,Object.assign(e.thumbs.swiper.originalParams,{watchSlidesProgress:!0,slideToClickedSlide:!1}),Object.assign(e.thumbs.swiper.params,{watchSlidesProgress:!0,slideToClickedSlide:!1}),e.thumbs.swiper.update();else if(y(s.swiper)){const r=Object.assign({},s.swiper);Object.assign(r,{watchSlidesProgress:!0,slideToClickedSlide:!1}),e.thumbs.swiper=new t(r),w=!0}return e.thumbs.swiper.el.classList.add(e.params.thumbs.thumbsContainerClass),e.thumbs.swiper.on("tap",p),!0}function a(s){const t=e.thumbs.swiper;if(!t||t.destroyed)return;const r=t.params.slidesPerView==="auto"?t.slidesPerViewDynamic():t.params.slidesPerView;let n=1;const d=e.params.thumbs.slideThumbActiveClass;if(e.params.slidesPerView>1&&!e.params.centeredSlides&&(n=e.params.slidesPerView),e.params.thumbs.multipleActiveThumbs||(n=1),n=Math.floor(n),t.slides.forEach(f=>f.classList.remove(d)),t.params.loop||t.params.virtual&&t.params.virtual.enabled)for(let f=0;f<n;f+=1)P(t.slidesEl,'[data-swiper-slide-index="'.concat(e.realIndex+f,'"]')).forEach(c=>{c.classList.add(d)});else for(let f=0;f<n;f+=1)t.slides[e.realIndex+f]&&t.slides[e.realIndex+f].classList.add(d);const m=e.params.thumbs.autoScrollOffset,b=m&&!t.params.loop;if(e.realIndex!==t.realIndex||b){const f=t.activeIndex;let c,S;if(t.params.loop){const T=t.slides.filter(x=>x.getAttribute("data-swiper-slide-index")==="".concat(e.realIndex))[0];c=t.slides.indexOf(T),S=e.activeIndex>e.previousIndex?"next":"prev"}else c=e.realIndex,S=c>e.previousIndex?"next":"prev";b&&(c+=S==="next"?m:-1*m),t.visibleSlidesIndexes&&t.visibleSlidesIndexes.indexOf(c)<0&&(t.params.centeredSlides?c>f?c=c-Math.floor(r/2)+1:c=c+Math.floor(r/2)-1:c>f&&t.params.slidesPerGroup,t.slideTo(c,s?0:void 0))}}o("beforeInit",()=>{const{thumbs:s}=e.params;if(!(!s||!s.swiper))if(typeof s.swiper=="string"||s.swiper instanceof HTMLElement){const t=E(),r=()=>{const d=typeof s.swiper=="string"?t.querySelector(s.swiper):s.swiper;if(d&&d.swiper)s.swiper=d.swiper,l(),a(!0);else if(d){const m=b=>{s.swiper=b.detail[0],d.removeEventListener("init",m),l(),a(!0),s.swiper.update(),e.update()};d.addEventListener("init",m)}return d},n=()=>{if(e.destroyed)return;r()||requestAnimationFrame(n)};requestAnimationFrame(n)}else l(),a(!0)}),o("slideChange update resize observerUpdate",()=>{a()}),o("setTransition",(s,t)=>{const r=e.thumbs.swiper;!r||r.destroyed||r.setTransition(t)}),o("beforeDestroy",()=>{const s=e.thumbs.swiper;!s||s.destroyed||w&&s.destroy()}),Object.assign(e.thumbs,{init:l,update:a})}function A(u){const{effect:e,swiper:i,on:o,setTranslate:h,setTransition:w,overwriteParams:p,perspective:l,recreateShadows:a,getEffectParams:s}=u;o("beforeInit",()=>{if(i.params.effect!==e)return;i.classNames.push("".concat(i.params.containerModifierClass).concat(e)),l&&l()&&i.classNames.push("".concat(i.params.containerModifierClass,"3d"));const r=p?p():{};Object.assign(i.params,r),Object.assign(i.originalParams,r)}),o("setTranslate",()=>{i.params.effect===e&&h()}),o("setTransition",(r,n)=>{i.params.effect===e&&w(n)}),o("transitionEnd",()=>{if(i.params.effect===e&&a){if(!s||!s().slideShadows)return;i.slides.forEach(r=>{r.querySelectorAll(".swiper-slide-shadow-top, .swiper-slide-shadow-right, .swiper-slide-shadow-bottom, .swiper-slide-shadow-left").forEach(n=>n.remove())}),a()}});let t;o("virtualUpdate",()=>{i.params.effect===e&&(i.slides.length||(t=!0),requestAnimationFrame(()=>{t&&i.slides&&i.slides.length&&(h(),t=!1)}))})}function k(u,e){const i=v(e);return i!==e&&(i.style.backfaceVisibility="hidden",i.style["-webkit-backface-visibility"]="hidden"),i}function V(u){let{swiper:e,duration:i,transformElements:o,allSlides:h}=u;const{activeIndex:w}=e,p=l=>l.parentElement?l.parentElement:e.slides.filter(s=>s.shadowRoot&&s.shadowRoot===l.parentNode)[0];if(e.params.virtualTranslate&&i!==0){let l=!1,a;h?a=o:a=o.filter(s=>{const t=s.classList.contains("swiper-slide-transform")?p(s):s;return e.getSlideIndex(t)===w}),a.forEach(s=>{I(s,()=>{if(l||!e||e.destroyed)return;l=!0,e.animating=!1;const t=new window.CustomEvent("transitionend",{bubbles:!0,cancelable:!0});e.wrapperEl.dispatchEvent(t)})})}}function M(u){let{swiper:e,extendParams:i,on:o}=u;i({fadeEffect:{crossFade:!1}}),A({effect:"fade",swiper:e,on:o,setTranslate:()=>{const{slides:p}=e,l=e.params.fadeEffect;for(let a=0;a<p.length;a+=1){const s=e.slides[a];let r=-s.swiperSlideOffset;e.params.virtualTranslate||(r-=e.translate);let n=0;e.isHorizontal()||(n=r,r=0);const d=e.params.fadeEffect.crossFade?Math.max(1-Math.abs(s.progress),0):1+Math.min(Math.max(s.progress,-1),0),m=k(l,s);m.style.opacity=d,m.style.transform="translate3d(".concat(r,"px, ").concat(n,"px, 0px)")}},setTransition:p=>{const l=e.slides.map(a=>v(a));l.forEach(a=>{a.style.transitionDuration="".concat(p,"ms")}),V({swiper:e,duration:p,transformElements:l,allSlides:!0})},overwriteParams:()=>({slidesPerView:1,slidesPerGroup:1,watchSlidesProgress:!0,spaceBetween:0,virtualTranslate:!e.params.cssMode})})}function j(){if(typeof document>"u")return;const u=document.querySelectorAll(".article-main-slider-wrap");u.length&&u.forEach(e=>{if(!e.swiper)try{let i=new g(e.nextElementSibling,{slidesPerView:8,loopedSlides:8,loop:!0,watchSlidesVisibility:!0,watchSlidesProgress:!0});new g(e,{loop:!0,effect:"fade",navigation:{nextEl:".article-main-slider-arrows .slider-next",prevEl:".article-main-slider-arrows .slider-prev"},thumbs:{swiper:i},modules:[C,O,M]})}catch(i){}})}export{j as a};