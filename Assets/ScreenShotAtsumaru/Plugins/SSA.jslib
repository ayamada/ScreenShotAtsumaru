var SSA = {

  $state : {},

  SetPtr : function (ptr) {
    //console.log("SetPtr", ptr);
    state.ptr = ptr;
  },

  OpenSSA : function () {
    //console.log("OpenSSA");
    if (window.RPGAtsumaru && window.RPGAtsumaru.experimental && window.RPGAtsumaru.experimental.screenshot && window.RPGAtsumaru.experimental.screenshot.displayModal) { window.RPGAtsumaru.experimental.screenshot.displayModal() }
  },

  Resolve : function (dataUrl) {
    //console.log("Resolve", dataUrl);
    state.resolver(UTF8ToString(dataUrl));
  },

  RegisterSSA : function () {
    //console.log("RegisterSSA");
    if (window.RPGAtsumaru && window.RPGAtsumaru.experimental && window.RPGAtsumaru.experimental.screenshot && window.RPGAtsumaru.experimental.screenshot.setScreenshotHandler) {
      try {
        window.RPGAtsumaru.experimental.screenshot.setScreenshotHandler(function () {
          //console.log("in setScreenshotHandler");
          state.dataUrl = null;
          return new Promise(function (resolve) {
            state.resolver = resolve;
            //console.log("before Module.dynCall_v in Promise in setScreenshotHandler");
            //console.log("state.ptr", state.ptr);
            Module.dynCall_v(state.ptr);
            //console.log("after Module.dynCall_v in Promise in setScreenshotHandler");
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
