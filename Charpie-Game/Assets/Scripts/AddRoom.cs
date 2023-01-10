using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour {

    // Import RoomTemplates scipt
    private RoomTemplates templates;

    void Start() {
        // Add new generated rooms to the rooms list in room templates when they are created
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        templates.rooms.Add(this.gameObject);
    }
}

