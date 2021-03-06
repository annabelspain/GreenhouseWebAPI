
/****************************************************************************
         * Add a new GreenhouseItem.
         *
         * 1) send an update to the DB
         * 2) if successful then add the item to the list
         ****************************************************************************/
function addNewGreenhouseItem(newItemValue) {
   // alert('6')
    // Get the value from the Input field in the FORM
    let greenhouseItemPlant = document.getElementById("newGreenhouseItemPlant").value.trim();
    let greenhouseItemAge = document.getElementById("newGreenhouseItemAge").value.trim();
    let greenhouseItemOrder = document.getElementById("newGreenhouseItemOrder").value.trim();
    let greenhouseItemDescription = document.getElementById("newGreenhouseItemDescription").value.trim();

    // Check that a value have added
    if (greenhouseItemPlant === "" || greenhouseItemAge === "" || greenhouseItemOrder === "" || greenhouseItemDescription === "") {
        alert("Please enter a value for your item");
        return;
    }
    createGreenhouseItem(greenhouseItemPlant, greenhouseItemAge, greenhouseItemOrder, greenhouseItemDescription);
    document.getElementById("newGreenhouseDescription").value = ""; createGreenhouseItem
}

/****************************************************************************
 * This function will add the a new Greenhouse item to the UL element
 * Specifically this will add:
 *
 *   <li>the item description<span class="close">X</>li>
 *
 * 1) add to DB
 * 2) if successful then add the item to the list
 *
 ****************************************************************************/
function addGreenhouseItemToDisplay(item) {
    let greenhouseItemNode = document.createElement("li");
    let descriptionTextNode = document.createTextNode(item["description"]);
    greenhouseItemNode.appendChild(descriptionTextNode);

    document.getElementById("greenhouseList").appendChild(greenhouseItemNode);

    let tickSpanNode = document.createElement("SPAN");
    let tickText = document.createTextNode("\u2713");  // \u2713 is unicode for the tick symbol
    tickSpanNode.appendChild(tickText);
    greenhouseItemNode.appendChild(tickSpanNode);
    tickSpanNode.className = "tickHidden";

    let closeSpanNode = document.createElement("SPAN");
    let closeText = document.createTextNode("X");
    closeSpanNode.className = "close";
    closeSpanNode.appendChild(closeText);
    greenhouseItemNode.appendChild(closeSpanNode);

    closeSpanNode.onclick = function (event) {
        // When the use press the "X" button, the click event is normally also passed to its parent element.
        // (i.e. the element containing the <SPAN>). In the case the LI element that is holding the GreenhouseItem
        // which would have resulted in a toggle of item between "DONE" and "NEW"
        //
        // stopPropagation() tells the event not to propagate
        event.stopPropagation();

        if (confirm("Are you sure that you want to delete " + item.description + "?")) {
            deleteGreenhouseItem(item["id"]);

            // Remove the HTML list element that is holding this Greenhouse item
            greenhouseItemNode.remove();
        }
    }

    greenhouseItemNode.onclick = function () {
        if (item["status"] === "NEW") {
            item["status"] = "DONE"
        } else {
            item["status"] = "NEW"
        }

        updateGreenhouseItem(item);

        greenhouseItemNode.classList.toggle("checked");
        tickSpanNode.classList.toggle("tickVisible");
    }

    if (item["status"] !== "NEW") {
        greenhouseItemNode.classList.toggle("checked");
        tickSpanNode.classList.toggle("tickVisible");
    }
}

/****************************************************************************
 * CRUD functions calling the REST API
 ****************************************************************************/

function createGreenhouseItem(greenhouseItemPlant, greenhouseItemAge, greenhouseItemOrder, greenhouseItemDescription) {

    // Create a new JSON object for the new item with the status of NEW
    // Since the id is generated by the microservice, we will use -1 as a dummy
    // If the POST is successful the microservice will store the new item in the database
    // and returns a JSON via the response with the generated id for the new item
    const newItem = { "Plant": greenhouseItemPlant, "Age": greenhouseItemAge, "Order": greenhouseItemOrder, "description": greenhouseItemDescription, "status": "NEW"};
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newItem)
    };

    //alert(greenhouseItemDescription);

    fetch('https://localhost:5001/greenhouse', requestOptions)
        // get the JSON content from the response
        .then((response) => {
            if (!response.ok) {
                alert("An error has occurred.  Unable to create the Greenhouse item")
                throw response.status;
            } else return response.json();
        })

        // add the item to the UL element so that it will appear in the browser
        .then(item => addGreenhouseItemToDisplay(item));
    alert('we made it');
}

// Load the list - expecting an array of Greenhouse_items to be returned
function readGreenhouseItems() {
    fetch('https://localhost:5001/greenhouse')
        // get the JSON content from the response
        .then((response) => {
            if (!response.ok) {
                alert("An error has occurred.  Unable to read the Greenhouse list")
                throw response.status;
            } else return response.json();
        })
        // Add the items to the UL element so that it can be seen
        // As items is an array, we will the array.map function to through the array and add item to the UL element
        // for display
        .then(items => items.map(item => addGreenhouseItemToDisplay(item)));
}

function updateGreenhouseItem(item) {
    const requestOptions = {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(item)
    };
    fetch('https://localhost:5001/greenhouse/' + item.id, requestOptions)
        .then((response) => {
            if (!response.ok) {
                alert("An error has occurred.  Unable to UPDATE the Greenhouse item")
                throw response.status;
            } else return response.json();
        })
}

function deleteGreenhouseItem(greenhouseItemId) {
    fetch("https://localhost:5001/greenhouse/" + greenhouseItemId, { method: 'DELETE' })
        .then((response) => {
            if (!response.ok) {
                alert("An error has occurred.  Unable to DELETE the Greenhouse item")
                throw response.status;
            } else return response.json();
        })
}