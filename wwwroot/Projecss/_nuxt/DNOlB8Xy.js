import{ak as f}from"./bIp8vrNC.js";function o(t){let s=new Image;return s.src="/images/game/"+t,s}function i(){this.rudolph=new e,this.obstacles=[],this.particles=[],this.closeParticles=[],this.waiting=!0,this.stage=0,this.score=0,this.highScore=!1,this.time,this.generateTerrain()}i.getInstance=function(){return i._instance||(i._instance=new i),i._instance};i.container=document.getElementById("container");i.canvas=document.getElementById("canvas");i.ctx=i.canvas.getContext("2d");i.help=document.getElementById("help-img");i.overImg=document.getElementById("over");i.numImg=o("n.png");i.prototype.draw=function(){i.ctx.clearRect(0,0,i.canvas.width,i.canvas.height),i.ctx.fillStyle="#ffffff",i.ctx.fillRect(0,i.canvas.height-18,i.canvas.width,18),this.drawScore(),this.particles.forEach(function(t){t.draw()}),this.obstacles.forEach(function(t){t.draw()}),this.rudolph.draw(),this.closeParticles.forEach(function(t){t.draw()})};i.prototype.drawScore=function(){let s=i.canvas.width-315;this.highScore&&(i.ctx.drawImage(i.numImg,0,30,96,30,s,12,48,15),this.drawNumber(Math.floor(this.highScore),s+120)),s+=168,i.ctx.drawImage(i.numImg,102,30,138,30,s,12,69,15),this.drawNumber(Math.floor(this.score),s+141)};i.prototype.drawNumber=function(t,s){let h=t.toString().split("");for(let a=h.length-1;a>=0;a--){s-=15;let n=h[a]*24;i.ctx.drawImage(i.numImg,n,0,24,30,s,12,12,15)}};i.prototype.update=function(t){let s=t-(this.time||t);this.time=t,this.score+=s/100,this.rudolph.update(s),this.obstacles.forEach(function(h){h.update(s)}),this.particles.forEach(function(h){h.update(s)}),this.closeParticles.forEach(function(h){h.update(s)}),this.checkCollision(),this.clean(),this.generate(),this.draw(),this.req()};i.prototype.checkCollision=function(){let t=this.rudolph;for(let s=0;s<this.obstacles.length;s++)if(this.obstacles[s].collidesWith(t)){this.gameOver();break}};i.prototype.start=function(){this.stage===2&&(this.obstacles=[],this.particles=[],this.time=!1,(!this.highScore||this.score>this.highScore)&&(this.highScore=this.score),this.score=0,this.rudolph.reset(),this.generateTerrain(),i.overImg.style.display="none"),this.stage=1,this.waiting=!1,this.rudolph.run(),i.help.src="/images/game/k2_"+f().$i18n.locale.value+".png",this.req()};i.prototype.gameOver=function(){this.stage=2,this.rudolph.stop(),i.overImg.style.display="initial",i.help.src="/images/game/k1_"+f().$i18n.locale.value+".png",setTimeout((function(){this.waiting=!0}).bind(this),400)};i.prototype.req=function(){this.stage===1&&requestAnimationFrame(this.update.bind(this))};i.prototype.clean=function(){this.obstacles=this.obstacles.filter(function(t){return t.visible}),this.particles=this.particles.filter(function(t){return t.visible}),this.closeParticles=this.closeParticles.filter(function(t){return t.visible})};i.prototype.generate=function(){let t=this.obstacles[this.obstacles.length-1];if(!t||t.x+t.w<i.canvas.width){let h=i.canvas.width+2*e.S+Math.round(Math.random()*10*e.S),a=Math.floor(Math.random()*2),n,c;switch(a){case 0:n=new u(h),this.obstacles.push(n);break;case 1:c=new l(h),this.obstacles.push(c);break;case 2:c=new l(h),this.obstacles.push(c),n=new u(h+c.w+6),this.obstacles.push(n);break;case 3:n=new u(h),this.obstacles.push(n),c=new l(h+n.w+6),this.obstacles.push(c);break}}this.particles.push(new g)};i.prototype.generateTerrain=function(){for(let t=0;t<i.canvas.width;t+=3){t+=3;{let s=new g;s.x=t,this.particles.push(s)}}};i.prototype.onkeydown=function(t){if(this.stage!==1&&this.waiting){switch(t.keyCode){case 32:case 38:t.preventDefault(),this.start();break}return}switch(t.keyCode){case 32:case 38:t.preventDefault(),this.rudolph.jump();break}};i.prototype.ontouchstart=function(t){if(this.stage!=1&&this.waiting){this.start();return}this.rudolph.jump()};i.prototype.onkeyup=function(t){this.keydown=!1};function r(t,s,h,a,n){this.x=t,this.y=s,this.w=h,this.h=a,this.img=n,this.timer=0,this.speed=-.5,this.dy=0,this.oy=0,this.moving=!1,this.visible=!0}r.prototype.draw=function(){i.ctx.drawImage(this.img,this.x,this.y,this.w,this.h)};r.prototype.update=function(t){this.moving&&(this.x+=this.speed*t,this.y+=this.dy*t,(this.x+this.w<0||this.y>i.canvas.height)&&(this.visible=!1))};r.prototype.run=function(){this.moving=!0};r.prototype.stop=function(){this.moving=!1};r.prototype.fixY=function(){};function e(){this.jumping=!1,this.runImg=0,this.alt=180}e.standingImg=o("r.png");e.jumpImg=o("r2.png");e.runImgs=[o("r0.png"),o("r1.png")];e.S=80;e.SW=58;e.X=110;e.Y=i.canvas.height-e.S-6;e.G=.06;e.prototype=new r(e.X,e.Y,e.SW,e.S,e.standingImg);e.prototype.run=function(){this.moving=!0,this.runImg=0,this.img=e.runImgs[this.runImg]};e.prototype.stop=function(){this.moving=!1,this.img=e.standingImg};e.prototype.reset=function(){this.jumping=!1,this.y=e.Y,this.dy=0,this.oy=0};e.prototype.jump=function(){this.jumping||(this.dy=-1,this.img=e.jumpImg,this.jumping=!0)};e.prototype.update=function(t){this.moving&&(this.jumping?(this.y+=this.dy*t,this.oy+=this.dy*t,this.y>=e.Y?(this.dy=0,this.y=e.Y,this.oy=0,this.img=e.runImgs[this.runImg],this.jumping=!1):this.dy+=e.G):this.timer<this.alt?this.timer+=t:(this.runImg?this.runImg=0:this.runImg=1,this.timer=0,this.img=e.runImgs[this.runImg]))};e.prototype.fixY=function(){this.y=e.Y+this.oy-6};function m(t,s,h){this.color=t,this.w=s,this.h=h,this.run()}m.prototype=new r(0,0,0,0,null);m.prototype.draw=function(){i.ctx.fillStyle=this.color,i.ctx.fillRect(this.x,this.y,this.w,this.h)};function g(){this.x=i.canvas.width,this.y=i.canvas.height-18,this.w=25}g.prototype=new m("#D8DADE",0,3);g.prototype.fixY=function(){this.y=i.canvas.height-18};function p(t,s){}p.prototype=new r(0,0,0,0,null);p.prototype.fixY=function(){this.y=i.canvas.height-this.h-18};p.prototype.collidesWith=function(t){return t.x<=this.x+this.w-72+t.oy/4&&t.x+t.w>=this.x+12-t.oy/4&&t.y+t.h>this.y};function l(t){this.x=t;let s=Math.floor(Math.random()*l.imgs.length),h=l.imgs[s];this.w=h.w,this.h=h.h,this.img=h.img,this.fixY(),this.run()}l.imgs=[{w:134,h:83,img:o("s1.png")},{w:128,h:84,img:o("s2.png")}];l.prototype=new p;function u(t){this.x=t;let s=Math.floor(Math.random()*u.imgs.length),h=u.imgs[s];this.w=h.w,this.h=h.h,this.img=h.img,this.fixY(),this.run()}u.imgs=[{w:67,h:58,img:o("b1.png")},{w:53,h:46,img:o("b2.png")}];u.prototype=new p;export{i as Game,e as Rudolph};