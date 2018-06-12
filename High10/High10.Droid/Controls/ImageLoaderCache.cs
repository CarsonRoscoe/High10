﻿using System;
using High10.ImageLoaders;

//Written by George Cook
namespace High10.Droid.Controls {
  /**
	 * caches available image loaders.
	 * TODO this needs to be written
	 */
  public static class ImageLoaderCache {
    //TODO change to a proper dictionary
    static ImageLoader _onlyLoader;

    public static ImageLoader GetImageLoader( FastImageRenderer imageRenderer ) {
      //TODO
      if ( _onlyLoader == null ) {
        _onlyLoader = new ImageLoader( Android.App.Application.Context, 64, 40 );
      }
      return _onlyLoader;
    }
  }
}

