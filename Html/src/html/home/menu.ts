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
    fa?: string;
}

let _module_menus: module_menu[] = [
    { code: 'menu_bank', name: '银行管理', url: './html/bank/banks .html', level: 1, hasChild: false },
    { code: 'menu_card', name: '卡片管理', url: '#', level: 1, hasChild: true },
    { code: 'menu_card_bank', pcode: 'menu_card', name: '我的卡片', url: './html/card/cards.html', level: 2, hasChild: false },
    { code: 'menu_card_bill', pcode: 'menu_card', name: '我的账单', url: './html/card/bills.html', level: 2, hasChild: false },
];

let menuli_1: IElement = { element: 'li' };
let menuli_2: IElement = { element: 'li', class: 'nav nav-second-level' };
let menuli_3: IElement = { element: 'li', class: 'nav nav-third-level' };

let createMenu = function (module_menus: module_menu[]) {
    let htmlMenu = '';
    let _module_menus =  module_menus.filter(t => t.level == 1);
    
}

let recmenu = function(module_menus: module_menu[]){
    let menu_html=new Element(); 
    module_menus.forEach(module_menu => {

        let li = createMenuli(module_menu);

        if (module_menu.hasChild) {
            let ul = document.createElement('ul');
            let ulclass = '';
            switch (module_menu.level) {
                case 1: break;
                case 2: ulclass = 'nav nav-second-level'; break;
                case 3: ulclass = 'nav nav-third-level'; break;
                default: break;
            }
            ul.setAttribute('class', ulclass);
            let _module_menus = module_menus.filter(t => t.pcode = module_menu.code);
            ul.appendChild(recmenu(_module_menus));

            li.appendChild(ul);
        }
        menu_html.appendChild(li);
    });

    return menu_html;
}

let createMenuli = function (module_menu: module_menu) {
    let li = document.createElement('li');
    let a = document.createElement('a');
    if (module_menu.url) a.setAttribute('url', module_menu.url);
    if (module_menu.fa) {
        let i = document.createElement('i');
        i.setAttribute('class', module_menu.fa);
        a.appendChild(i);
    }
    li.appendChild(a);
    return li;
}

// <ul class="nav nav-third-level">                
//     <li>
//         <a href="#">Third Level Item</a>
//     </li>
// </ul>