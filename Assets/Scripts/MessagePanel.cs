using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MessagePanel : MonoBehaviour
{
	[SerializeField] private GameObject _messagePanel;
	[SerializeField] private TMP_Text _text;
	[SerializeField] private Button _ok;
	[SerializeField] private Button _cancel;
	[SerializeField] private string _messageTextTransaction;
	[SerializeField] private string _messageTextNotEnoughMoney;

	public event UnityAction SellButtonClickOk;

	private void OnEnable()
	{
		_ok.onClick.AddListener(OnButtonClick);
	}

	private void OnDisable()
	{
		_ok.onClick.RemoveListener(OnButtonClick);
	}

	public void Transaction()
	{
		OpenPanel(_messagePanel);
		_text.text = _messageTextTransaction;
		SetActiveButton(true, true);
	}

	public void NotEnoughMoney()
	{
		OpenPanel(_messagePanel);
		_text.text = _messageTextNotEnoughMoney;
		SetActiveButton(false, true);
	}

	private void OpenPanel(GameObject panel)
	{
		panel.SetActive(true);
	}

	public void ClosePanel(GameObject panel)
	{
		panel.SetActive(false);
		SetActiveButton(false, false);
	}

	private void SetActiveButton(bool ok, bool cancel)
	{
		_ok.gameObject.SetActive(ok);
		_cancel.gameObject.SetActive(cancel);
	}

	private void OnButtonClick()
	{		
		SellButtonClickOk?.Invoke();
		ClosePanel(_messagePanel);
	}
}
