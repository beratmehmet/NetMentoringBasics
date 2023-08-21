// Task #1
var item = "I can eat bananas all day";
var result = item.slice(10,17).toUpperCase();
window.alert(result);

// Task #2

// Define array
const cars = ["Saab", "Volvo", "BMW"];

// Get BMW
const bmw = cars[2];
console.log("BMW: " + bmw);

// Change first element to "Porsche"
cars[0] = "Prosche";
console.log("Change first element: " + cars);

// Remove last item
cars.pop();
console.log("Remove last item: " + cars);

// Add "Audi"
cars.push("Audi");
console.log("Add 'Audi:' " + cars);

//Splice Audi and Volvo
const spliced = cars.splice(1,2);
console.log("Spliced items: " + spliced);