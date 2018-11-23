import IIndex from '../../ts/index';
import '../../vendor/metisMenu/metisMenu.min.js';

class Menu implements IIndex {
    async init() {
        //$('#side-menu').metisMenu();
    }
}

// export const menu = new Menu();
new Menu().init();


export default interface IElement {
    element: string;
    id?: string;
    name?: string;
    val?: string;
    text?: string;
    html?: string;
    class?: string;
    style?: string;
}

class module_menu {
    code: string;
    pcode?: string;
    name: string;
    url: string;
    level: number;
    hasChild: boolean;
    child?: Array<module_menu>;
}

let _module_menus: module_menu[] = [
    { code: 'menu_bank', name: '银行管理', url: './html/bank/banks .html', level: 1, hasChild: false },
    { code: 'menu_card', name: '卡片管理', url: '#', level: 1, hasChild: true },
    { code: 'menu_card_bank', pcode: 'menu_card', name: '我的卡片', url: './html/card/cards.html', level: 2, hasChild: false },
    { code: 'menu_card_bill', pcode: 'menu_card', name: '我的账单', url: './html/card/bills.html', level: 2, hasChild: false },
];

let menuli_1: IElement = { element: 'li' };
let menuli_2: IElement = { element: 'li' };
let menuli_3: IElement = { element: 'li' };

let createMenu = function (module_menus: module_menu[]) {
    let htmlMenu = '';
    module_menus.forEach(module_menu => {
        let menuli = menuli_1
        let li = document.createElement('li');
        if (module_menu.hasChild) {

        }
    });
}

let createMenuElement = function (module_menu: module_menu, menuli: IElement) {
    switch (module_menu.level) {
        case 1: $.extend(menuli, menuli_1); break;
        case 2: $.extend(menuli, menuli_2); break;
        case 3: $.extend(menuli, menuli_3); break;
        default: return;
    }
}

let createMenuli = function (module_menu: module_menu, module_menus: module_menu[]) {

}