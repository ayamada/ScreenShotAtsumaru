var SSA = {

  $funcs : {},

  SetDataUrl : function (dataUrl) {
    funcs.dataUrl = Pointer_stringify(dataUrl);
  },

  OpenSSA : function () {
    if (window.RPGAtsumaru && window.RPGAtsumaru.experimental && window.RPGAtsumaru.experimental.screenshot && window.RPGAtsumaru.experimental.screenshot.displayModal) { window.RPGAtsumaru.experimental.screenshot.displayModal() }
  },

  RegisterSSA : function () {
    if (window.RPGAtsumaru && window.RPGAtsumaru.playerFeatures && ! window.RPGAtsumaru.playerFeatures.takeScreenShot) {
      window.RPGAtsumaru.playerFeatures.takeScreenShot = function () { return funcs.dataUrl };
    }
  }
};

autoAddDeps(SSA, '$funcs');
mergeInto(LibraryManager.library, SSA);
