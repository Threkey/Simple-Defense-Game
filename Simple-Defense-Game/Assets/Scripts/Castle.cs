using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    GameManager gm;

    public Slider sliderHp;

    float castleHp, castleMaxHp;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;

        castleMaxHp = 100f;
        castleHp = castleMaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHp();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            castleHp -= 10f;
        }
    }

    void UpdateHp()
    {
        sliderHp.value = castleHp / castleMaxHp;

        if(castleHp <= 0)
        {
            sliderHp.gameObject.transform.Find("Fill Area").gameObject.SetActive(false);
        }
    }
}
