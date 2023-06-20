using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextArchitecture
{
    private TextMeshProUGUI tmprText;
    private string targetText;
    private Coroutine buildProcess;
    public TextArchitecture(TextMeshProUGUI tmprText)
    {
        this.tmprText = tmprText;
    }
    public Coroutine Build(string target)
    {
        targetText = target;
        Stop();
        buildProcess = tmprText.StartCoroutine(Building());
        return buildProcess;
    }
    IEnumerator Building()
    {
        Prepeare();
        while (tmprText.maxVisibleCharacters < tmprText.textInfo.characterCount)
        {
            tmprText.maxVisibleCharacters++;

            yield return new WaitForSeconds(0.15f);
        }
        buildProcess = null;
        yield return null;
    }
    private void Stop()
    {
        if (buildProcess == null)
            return;
        tmprText.StopCoroutine(buildProcess);
        buildProcess = null;
    }
    private void Prepeare()
    {
        tmprText.text = targetText;
        tmprText.maxVisibleCharacters = 0;

    }
}
