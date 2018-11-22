
(() => {
    const startupUrl = (() => {
        var scripts = document.getElementsByTagName("script");
        var script = scripts[scripts.length - 1];
        console.log(scripts);
        console.log(script);
        return script.src || script.getAttribute("src");
    })();

    async function run() {
        console.log(startupUrl);
    };
    (async () => {
        try {
            await run();
        } catch (ex) {
            console.error(ex);
            throw ex;
        }
    })();
});