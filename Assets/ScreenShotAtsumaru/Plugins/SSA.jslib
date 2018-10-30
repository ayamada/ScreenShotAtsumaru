var SSA = {

  $state : {},

  SetPtr : function (ptr) {
    state.ptr = ptr;
  },

  OpenSSA : function () {
    if (window.RPGAtsumaru && window.RPGAtsumaru.experimental && window.RPGAtsumaru.experimental.screenshot && window.RPGAtsumaru.experimental.screenshot.displayModal) { window.RPGAtsumaru.experimental.screenshot.displayModal() }
  },

  Resolve : function (dataUrl) {
    state.resolver(Pointer_stringify(dataUrl));
  },

  RegisterSSA : function () {
    if (window.RPGAtsumaru && window.RPGAtsumaru.playerFeatures && ! window.RPGAtsumaru.playerFeatures.takeScreenShot) {
      var f = function () {
        state.dataUrl = null;
        return new Promise(function (resolve) {
          state.resolver = resolve;
          Runtime.dynCall('v', state.ptr, 0);
        });
      };
      window.RPGAtsumaru.playerFeatures.takeScreenShot = f;
    }
  }
};

autoAddDeps(SSA, '$state');
mergeInto(LibraryManager.library, SSA);
