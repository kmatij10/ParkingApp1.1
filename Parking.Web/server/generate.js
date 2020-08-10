var faker = require('faker');

var database = { protests: [] };

for (var i = 1; i<= 15; i++) {
  database.protests.push({
    id: i,
    title: faker.lorem.words(),
    description: faker.lorem.sentences(),
    // image_url: "https://source.unsplash.com/1600x900/?product",
    image_url: "https://i.picsum.photos/id/371/300/200.jpg"
  });
}

console.log(JSON.stringify(database));
