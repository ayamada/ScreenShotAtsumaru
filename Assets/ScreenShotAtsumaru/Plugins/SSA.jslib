var SSA = {

  $state : {},

  SetPtr : function (ptr) {
    state.ptr = ptr;
  },

  OpenSSA : function () {
    if (window.RPGAtsumaru && window.RPGAtsumaru.experimental && window.RPGAtsumaru.experimental.screenshot && window.RPGAtsumaru.experimental.screenshot.displayModal) { window.RPGAtsumaru.experimental.screenshot.displayModal() }
  },

  Resolve : function (dataUrl) {
    state.resolver(UTF8ToString(dataUrl));
  },

  RegisterSSA : function () {
    if (window.RPGAtsumaru && window.RPGAtsumaru.experimental && window.RPGAtsumaru.experimental.screenshot && window.RPGAtsumaru.experimental.screenshot.setScreenshotHandler) {
      try {
        window.RPGAtsumaru.experimental.screenshot.setScreenshotHandler(function () {
          state.dataUrl = null;
          return new Promise(function (resolve) {
            state.resolver = resolve;
            Runtime.dynCall('v', state.ptr, 0);
          });
        });
      }
      catch (e) {
        if (window.console) {
          window.console.log("Failed to registerSSA");
        }
      }
    }
  }
};

autoAddDeps(SSA, '$state');
mergeInto(LibraryManager.library, SSA);
