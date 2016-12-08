#AutoComponentCathes
---
GetComponent,<br>
FindObjectOfType,<br>
GetComponents,<br>
FindObjectOfTypes,<br>
GetComponentInChildren,<br>
GetComponentsInChildren,<br>
<br>
のキャッシュの生成を容易にするライブラリ
<br>
<br>
要は

```
private SpriteRenderer _sp
private SpriteRenderer sp
{
	get
	{
		if(_sp == null)
		{
			_sp = GetComponent<SpriteRenderer>();
		}
		return _sp;
	}
}

```

を

```
private SpriteRenderer sp { get { return this.AutoGetComponent<SpriteRenderer>(); } }

```
の一行だけで書けるもの。


---


##サンプルコード
```
using UnityEngine;
using System.Collections;
using AutoComponentCathes;

public class AutoComponentCathesTest : MonoBehaviour
{
	//一度SpriterendererをGetComponentした後は二度と呼ばずに、キャッシュされたものから取得
	private SpriteRenderer sp { get { return this.AutoGetComponent<SpriteRenderer>(); } }

	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		sp.color = Color.blue;
	}
}

```

---


##比較

###コード1:毎回GetComponent

```

	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		GetComponent<SpriteRenderer>().color = Color.Red;
	}
```
⇛毎回GetComponentを呼ぶので処理が重い

###コード2:Start(Awake)でキャッシュ

```
	public SpriteRenderer sp;

	// Use this for initialization
	void Start()
	{
		sp = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		sp.color = Color.Red;
	}
```
⇛コード1に比べて、Componentがキャッシュされて早くなるが、他のオブジェクトからの参照が自分のStart(Awake)よりも先だとNullを吐く
###コード3:プロパティを使う

```
	private SpriteRenderer _sp
	public  SpriteRenderer sp
	{
		get
		{
			if(_sp == null)
			{
				_sp = GetComponent<SpriteRenderer>();
			}
			return _sp;
		}
	}
	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		sp.color = Color.Red;
	}
```
⇛コード2におけるnullの問題がなくなったが冗長。

###コード4:AutoGetComponetを使う
```
	public SpriteRenderer sp { get { return this.AutoGetComponent<SpriteRenderer>(); } }

	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		sp.color = Color.Red;
	}
```
⇛コード3の処理が一行になった。

---

##使い方
<br>
unitypackageを導入して、用いるクラスに

```
using AutoComponentCathes;
```
を入れるだけでOKです。

---

##バージョン情報
ver1.0.1 Scene切替時に、別のシーンに同じクラスがあるとうまく動作しない不具合を修正(マルチシーンには非対応)<br>
ver1.0.0 リリース
