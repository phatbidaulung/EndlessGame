using UnityEngine;

public class EnemyFly : EnemyController {
    private void Start() {
        this.transform.position = new Vector2(this.transform.position.x, 4.8f);
    }
}