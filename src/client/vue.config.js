/*
  This is required because the Webpack Dev Middleware
  injects the HMR module causing two to be loaded.

  This removes the one that is already there.

*/
module.exports = {
  configureWebpack: function(config) {
    let plugins = [];
    for (let i = 0; i < config.plugins.length; i++) {
      if(config.plugins[i].constructor.name !== 'HotModuleReplacementPlugin') {
        plugins.push(config.plugins[i]);
      }
    }

    config.plugins = plugins;
  }
}