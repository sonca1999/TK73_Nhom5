import { AppPage } from './../../../e2e/src/app.po';
import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
declare var $:any;

@Component({
  selector: 'app-docgia',
  templateUrl: './docgia.component.html',
  styleUrls: ['./docgia.component.css']
})
export class DocgiaComponent implements OnInit {

  docgia:any ={
    data:[],
    totalRecord:0,
    page:0,
    size:4,
    totalPage:0
  };

  docgia1:any ={
    tenDg:"Mười",
    sdt:"1234567897",
    maThe:"7"
  };

  isEdit: boolean = true;

  constructor(
    private http: HttpClient, @Inject('BASE_URL') baseUrl: string
  ) { }

  ngOnInit() {
    this.searchDocgia(1);
  }

  searchDocgia(cPage){
    let x = {
      page:cPage,
      size:4,
      keyword:""
    }
    this.http.post('https://localhost:44304/'​+'api/Docgia/search-doc-gia', x).subscribe(result => {
      this.docgia = result;
      this.docgia = this.docgia.data;
      console.log(this.docgia);
    }, error => console.error(error));
  }

  searchNext(){
    if(this.docgia.page < this.docgia.totalPage){
      let nextPage = this.docgia.page + 1;
      let x = {
        page:nextPage,
        size:4,
        keyword:""
      }
      this.http.post('https://localhost:44304/'​+'api/Docgia/search-doc-gia', x).subscribe(result => {
        this.docgia = result;
        this.docgia = this.docgia.data;
        console.log(this.docgia);
      }, error => console.error(error));
    }
    else{
      alert("Bạn đang ở trang cuối cùng!");
    }
  }

  searchPrevious(){
    if(this.docgia.page > 1){
      let previousPage = this.docgia.page - 1;
      let x = {
        page:previousPage,
        size:4,
        keyword:""
      }
      this.http.post('https://localhost:44304/'​+'api/Docgia/search-doc-gia', x).subscribe(result => {
        this.docgia = result;
        this.docgia = this.docgia.data;
        console.log(this.docgia);
      }, error => console.error(error));
    }
    else{
      alert("Bạn đang ở trang đầu tiên!");
    }
  }

  openModal(isNew,index)
  {
    if(isNew)
    {
      this.isEdit = false;
      this.docgia1 ={
        tenDg:"",
        sdt:"",
        maThe:""
      }
    }
    else
    {
      this.isEdit = true;
      this.docgia1 = this.docgia.data[index];
    }
    $('#exampleModal').modal("show");
  }

  addDocgia()
  {
    var x = this.docgia1;
    this.http.post('https://localhost:44304/'​+'api/Docgia/create-doc-gia',x).subscribe(result => {
        var res:any = result;
        if(res.success)
        {
          this.docgia1 = res.data;
          this.isEdit = true;
          this.searchDocgia(1);
          alert("Độc giả mới đã được tạo thành công!");
        }
      }, error => console.error(error));
    }

  updateDocgia()
  {
    var x = this.docgia1;
    this.http.post('https://localhost:44304/'​+'api/Docgia/update-doc-gia',x).subscribe(result => {
        var res:any = result;
        if(res.success)
        {
          this.docgia1 = res.data;
          this.isEdit = true;
          this.searchDocgia(1);
          alert("Thông tin độc giả đã được thay đổi thành công!");
        }
      }, error => console.error(error));
    }

  deleteDocgia(index)
  {
    var r = confirm("Bạn có chắc chắn xóa?");
    if (r==true)
    {
      this.docgia1 = this.docgia.data[index];
      var x = this.docgia1;
      this.http.post('https://localhost:44304/' + 'api/Docgia/delete-doc-gia/', x)
      .subscribe(result => {
        var res:any = result;
        if(res.success)
        {
          this.searchDocgia(1);
          alert("Đã xóa thành công!");
        }
        else {
          alert(res.message);
        }
    }, error => {
      console.error(error);
      alert(error);
    });
    }
  }
}
