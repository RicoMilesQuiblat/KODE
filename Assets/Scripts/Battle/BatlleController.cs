using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


public class BatlleController : MonoBehaviour
{
    private int currentAnswer;
    private bool oneIsclicked = false;
    private bool twoIsclicked = false;
    private bool threeIsclicked = false;
    private bool fourIsclicked = false;

    public float enemyHp = 26f;
    public float playerHp = 26f;

    public Slider playerHpSlider;
    public Slider monsterHpSlider;

    public Text questionText;
    public Animator animator;
    
    
    private List<int> answers = new List<int>(){
        1,2,1,
        1,4,2,1,
        1,4,2,4,2,1,
        1,4,2,3,4,2,1,
        1,4,2,3,4,2,1,

    };

    private void OnEnable(){
        enemyHp = 26f;
        playerHp = 26f;
        playerHpSlider.value = playerHp;
        monsterHpSlider.value = enemyHp;
    }
    private void Update(){
        if(currentAnswer == 0){
            questionText.text = "Create a flowchart to display 'Hello, World!' on the screen.";
            if(oneIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                animator.SetTrigger("Hit");
                monsterHpSlider.value = enemyHp;
            }else if(!oneIsclicked && twoIsclicked || threeIsclicked || fourIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            } 
        }else if(currentAnswer == 1){
            if(twoIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                animator.SetTrigger("Hit");
                monsterHpSlider.value = enemyHp;
            }else if(!twoIsclicked && oneIsclicked || threeIsclicked || fourIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            } 
        }else if(currentAnswer == 2){
            if(oneIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
                questionText.text = "Make a flowchart that declares a char variable, takes a character input, and then displays it.";
            }else if(!oneIsclicked && twoIsclicked || threeIsclicked || fourIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            } 
        }else if(currentAnswer == 3){
            if(oneIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!oneIsclicked && twoIsclicked || threeIsclicked || fourIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            } 
        }else if(currentAnswer == 4){
            if(fourIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!fourIsclicked && oneIsclicked || twoIsclicked || threeIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            }
        }else if(currentAnswer == 5){
            if(twoIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!twoIsclicked && oneIsclicked || threeIsclicked || fourIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            } 
        }else if(currentAnswer == 6){
            if(oneIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
                questionText.text = "Design a flowchart that sums two user-provided integers and displays the result.";
            }else if(!oneIsclicked && twoIsclicked || threeIsclicked || fourIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            } 
        }else if(currentAnswer == 7){
            if(oneIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!oneIsclicked && twoIsclicked || threeIsclicked || fourIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            } 
        }else if(currentAnswer == 8){
            if(fourIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!fourIsclicked && oneIsclicked || twoIsclicked || threeIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            }
        }else if(currentAnswer == 9){
            if(twoIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!twoIsclicked && oneIsclicked || threeIsclicked || fourIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            } 
        }else if(currentAnswer == 10){
            if(fourIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!fourIsclicked && oneIsclicked || twoIsclicked || threeIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            }
        }else if(currentAnswer == 11){
            if(twoIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!twoIsclicked && oneIsclicked || threeIsclicked || fourIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            } 
        }else if(currentAnswer == 12){
            if(oneIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
                questionText.text = "Create a flowchart to check if an input number is >, <, or == 100 and output a corresponding message.";
            }else if(!oneIsclicked && twoIsclicked || threeIsclicked || fourIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            } 
        }else if(currentAnswer == 13){
            if(oneIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!oneIsclicked && twoIsclicked || threeIsclicked || fourIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            } 
        }else if(currentAnswer == 14){
            if(fourIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!fourIsclicked && oneIsclicked || twoIsclicked || threeIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            }
        }else if(currentAnswer == 15){
            if(twoIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!twoIsclicked && oneIsclicked || threeIsclicked || fourIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            } 
        }else if(currentAnswer == 16){
            if(threeIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!threeIsclicked && oneIsclicked || twoIsclicked || fourIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            }
        }else if(currentAnswer == 17){
            if(fourIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!fourIsclicked && oneIsclicked || twoIsclicked || threeIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            }
        }else if(currentAnswer == 18){
            if(twoIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
                questionText.text = "Build a flowchart that keeps asking for numbers and adds them until the total is ≥ 50, then outputs the total.";
            }else if(!twoIsclicked && oneIsclicked || threeIsclicked || fourIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            } 
        }else if(currentAnswer == 19){
            if(oneIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!oneIsclicked && twoIsclicked || threeIsclicked || fourIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            } 
        }else if(currentAnswer == 20){
            if(oneIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!oneIsclicked && twoIsclicked || threeIsclicked || fourIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            } 
        }else if(currentAnswer == 21){
            if(fourIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!fourIsclicked && oneIsclicked || twoIsclicked || threeIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            }
        }else if(currentAnswer == 22){
            if(twoIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!twoIsclicked && oneIsclicked || threeIsclicked || fourIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            } 
        }else if(currentAnswer == 23){
            if(threeIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!threeIsclicked && oneIsclicked || twoIsclicked || fourIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            }
        }else if(currentAnswer == 24){
            if(fourIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!fourIsclicked && oneIsclicked || twoIsclicked || threeIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            }
        }else if(currentAnswer == 25){
            if(twoIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!twoIsclicked && oneIsclicked || threeIsclicked || fourIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;
            } 
        }else if(currentAnswer == 26){
            if(oneIsclicked){
                enemyHp -= 1;
                currentAnswer += 1;
                monsterHpSlider.value = enemyHp;
                animator.SetTrigger("Hit");
            }else if(!oneIsclicked && twoIsclicked || threeIsclicked || fourIsclicked){
                playerHp -= 1;
                playerHpSlider.value = playerHp;    
            } 
        }
        oneIsclicked = false;
        twoIsclicked = false;
        threeIsclicked = false;
        fourIsclicked = false;
    }
   
    public void buttonClick1(){
        oneIsclicked = true;
    }
    public void buttonClick2(){
        twoIsclicked = true;
    }
    public void buttonClick3(){
        threeIsclicked = true;
    }

    public void buttonClick4(){
        fourIsclicked = true;
    }
    



}

