console.log("Oi");
var jsonToSend = {};
var articles = [];

function jsonFactory() {
  buildJson(jsonToSend);
  sendJson(jsonToSend).then(result => {
    if (result == 200) {
      document.getElementById("result-field").innerHTML += `<div class="form-card" id="success-card">
      <h2 class="fs-title text-center">Submissão realizada !</h2> <br><br>
      <div class="row justify-content-center">
          <div class="col-3"> <img src="https://img.icons8.com/color/96/000000/ok--v2.png"
                  class="fit-image"> </div>
      </div> <br><br>
      <div class="row justify-content-center">
          <div class="col-7 text-center">
              <h5>Obrigado pela colaboração, seus dados foram enviados com sucesso!</h5>
          </div>
      </div>
  </div>`
    } else {
      document.getElementById("result-field").innerHTML += `<div class="form-card" id="fail-card">
      <h2 class="fs-title text-center">Submissão não realizada !</h2> <br><br>
      <div class="row justify-content-center">
          <div class="col-3"> <img src="https://loading.io/s/icon/jxjyiv.svg"
                  class="fit-image"> </div>
      </div> <br><br>
      <div class="row justify-content-center">
          <div class="col-7 text-center">
              <h5>Algo deu errado! entre em contado com os desenvolvedores responsáveis para solucionar o problema</h5>
          </div>
      </div>
  </div>`
    }
  })
}

function getName() {
  var inputName = document.getElementById("uname");
  return inputName.value;
}

function getAsks(className, textIndex, inputIndex, checkBox) {
  checkBoxAsks = []
  var fields = document.getElementsByClassName(className);
  for (var i = 0; i < fields.length; i++) {
    var formCheck = fields[i].children;
    checkBoxAsks.push({
      text: formCheck[textIndex].innerHTML.trim(),
      value: checkBox ? formCheck[inputIndex].checked : formCheck[inputIndex].value.trim()
    })
  }
  return checkBoxAsks;
}

function addArticle() {
  if (articleIsValid()) {
    var article = {}
    article.type = parseInt(document.getElementById("articleType").value);
    article.description = document.getElementById("articleDescription").value;
    article.associatedProjectId = parseInt(document.getElementById("articleAssociatedProject").value);
    article.q1 = document.getElementById("q1").checked;
    article.q2 = document.getElementById("q2").checked;
    article.associatedProgram = parseInt(document.getElementById("articleAssociatedProgram").value);
    articles.push(article);

    document.getElementById('articleList').innerHTML +=
      `<div class="d-flex justify-content-between my-3" id="article-item-${articles.length - 1}">
    <h2> ${document.getElementById("articleDescription").value} </h2>
      <button type="button" class="btn btn-danger" onclick="removeArticle(${articles.length - 1})" >Excluir</button>
  </div >`
    console.log(articles);
    resetArticle();
  } else {
    alert("Preencha todos os dados corretamente!");
  }
}

function removeArticle(index) {
  document.getElementById(`article-item-${index}`).remove();
  articles.splice(index, 1);
}

function resetArticle() {
  document.getElementById("articleType").value = 0;
  document.getElementById("articleDescription").value = "";
  document.getElementById("articleAssociatedProject").value = 0;
  document.getElementById("q1").checked = false;
  document.getElementById("q2").checked = false;
  document.getElementById("articleAssociatedProgram").value = 0;
}

function articleIsValid() {
  if (document.getElementById("articleType").value == 0)
    return false;
  if (document.getElementById("articleDescription").value == "")
    return false;
  if (document.getElementById("articleAssociatedProject").value == 0)
    return false;
  if (document.getElementById("articleAssociatedProgram").value == 0)
    return false;
  return true;
}

function buildJson(jsonToSend) {
  jsonToSend.name = getName();
  jsonToSend.articles = articles;
  jsonToSend.checkBoxAsks = getAsks("form-check", 1, 0, true);
  jsonToSend.textAsks = getAsks("form-group", 0, 1, false);
  return jsonToSend;
}

async function sendJson(jsonToSend) {
  console.log(jsonToSend)
  try {
    const response = await axios({
      method: 'post',
      url: '/api/v1/formsubmit',
      data: jsonToSend
    })
    return await response.status;
  } catch (error) {
    console.error(error);
  }
}

function logJson(jsonToSend) {
  console.log(jsonToSend);
}

