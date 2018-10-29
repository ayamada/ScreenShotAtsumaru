var SSA = {

  $funcs : {},

  SetDataUrl : function (dataUrl) {
    funcs.dataUrl = Pointer_stringify(dataUrl);
  },

  SetPtr : function (ptr) {
    funcs.ptr = ptr;
  },

  OpenSSA : function () {
    if (window.RPGAtsumaru && window.RPGAtsumaru.experimental && window.RPGAtsumaru.experimental.screenshot && window.RPGAtsumaru.experimental.screenshot.displayModal) { window.RPGAtsumaru.experimental.screenshot.displayModal() }
  },

  RegisterSSA : function () {
    if (window.RPGAtsumaru && window.RPGAtsumaru.playerFeatures && ! window.RPGAtsumaru.playerFeatures.takeScreenShot) {
      var f = function () {
        Runtime.dynCall('v', funcs.ptr, 0);
        return funcs.dataUrl;
      };
      window.RPGAtsumaru.playerFeatures.takeScreenShot = f;
    }
  }
};

autoAddDeps(SSA, '$funcs');
mergeInto(LibraryManager.library, SSA);
