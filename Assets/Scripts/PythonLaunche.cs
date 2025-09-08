using UnityEngine;
using System.Diagnostics; // lets us start external apps

public class PythonLauncher : MonoBehaviour {
    void Start() {
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = "python"; // or "python3" depending on your setup
        start.Arguments = "HandTrakingMediapipe.py"; // your python script
        start.WorkingDirectory = Application.dataPath + "/Python"; // adjust to your folder
        start.UseShellExecute = false;

        Process.Start(start);

        UnityEngine.Debug.Log("✅ Python script launched!");
    }
}
