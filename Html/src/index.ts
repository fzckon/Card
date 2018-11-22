console.log('index');
import * as $ from 'jquery';


export default interface IIndex {
    init(): any;
}

class Index implements IIndex {
    async init() {
        if (true) await $('#main').load('./html/home/main.html');
        else await $('#main').load('./html/home/login.html');
    }
}

export const index = new Index();
index.init();