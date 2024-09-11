using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CMD 
{
    public CMD(List<string> cmds) {
        Process process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.WorkingDirectory = ".";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardInput = true;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.RedirectStandardError = true;
        process.OutputDataReceived += OutputHandler;
        process.ErrorDataReceived += ErrorDataHandler;
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        for (int i = 0; i < cmds.Count; i++) {
            process.StandardInput.WriteLine(cmds[i]);
        }
        process.StandardInput.WriteLine("exit");
        process.WaitForExit();
    }

    private void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine) {
        if (!string.IsNullOrEmpty(outLine.Data)) {
            UnityEngine.Debug.Log(outLine.Data);
        }
    }
    private void ErrorDataHandler(object sendingProcess, DataReceivedEventArgs outLine) {
        if (!string.IsNullOrEmpty(outLine.Data)) {
            UnityEngine.Debug.LogError(outLine.Data);
        }
    }
}
