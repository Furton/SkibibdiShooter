/*using UnityEngine;

using UnityEditor;

namespace AssetBundles

{

    public class BuildScript

    {

        public static void BuildPlayer()

        {

            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();

            // example hard-coded platform manifest path

            buildPlayerOptions.assetBundleManifestPath = "AssetBundles/1.manifest";
            buildPlayerOptions.assetBundleManifestPath = "AssetBundles/2.manifest";

            // build the Player ensuring engine code is included for 

            // AssetBundles in the manifest.

            BuildPipeline.BuildPlayer(buildPlayerOptions);

        }

    }

}*/