//console.log('main');
import IIndex from '../../ts/index';

class Main implements IIndex {
    async init() {
        await $('.navbar-header').load('./html/home/head.html');
        await $('.navbar-top-links').load('./html/home/top.html');
        await $('#side-menu').load('./html/home/menu.html', function () { });
        await $('#content').load('./html/home/content.html');
        await $(".page-header").text("Title");

        // $.get("menu.html", function (result) {
        //     $("#side-menu").html(result);
        //     $('#side-menu').metisMenu();
        // });
    }
}

// export const main = new Main();
 new Main().init();