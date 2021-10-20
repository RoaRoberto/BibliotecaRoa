import { Component, OnInit } from '@angular/core';
import { AutorDTO } from '../dto/AutorDTO';
import { LibroDTO } from '../dto/LibroDTO';
import { MessageToast } from '../dto/MessageToast';
import { AutorService } from '../services/Autor.service';
import { LibroService } from '../services/Libro.service';


@Component({
  selector: 'app-libro',
  templateUrl: './libro.component.html',
  styleUrls: ['./libro.component.css']
})
export class LibroComponent implements OnInit {
  libros: LibroDTO[] = [];
  autores: AutorDTO[] = [];
  regModel: LibroDTO = {} as LibroDTO;
  showNew: Boolean = false;
  submitType: string = 'Guardar';
  selectedRow: number = 0;
  message: MessageToast = {} as MessageToast;
  show: boolean = false;
  constructor(private libroservice: LibroService, private autoresService: AutorService) {

  }

  async ngOnInit() {
    await this.getData();
  }

  async getData() {
    this.libros = await this.libroservice.getAllAsync();
    this.autores = await this.autoresService.getAllAsync();
  }

  onNew() {

    this.submitType = 'Guardar';
    this.regModel = { autor: { nombreCompleto: "seleccione un autor", id: 0 } as AutorDTO } as LibroDTO;
    this.showNew = true;
  }

  async onSave() {
    if (this.submitType === 'Guardar') {
      if (this.regModel.autor.id != 0) {

        try {
          const response = await this.libroservice.createAsync(this.regModel);
          console.log(response);
          this.getData();
          this.showNew = false;
          this.regModel = {} as LibroDTO;
          this.showAlert("Exito", "Se ha creado el libro correctamente");
        } catch (error: any) {
          console.log(error);
          this.showAlert("Error", error.error);
        }

      } else {
        this.showAlert("Notificación", "Debe seleccionar un autor");
      }
    } else {
      const response = await this.libroservice.updateAsync(this.regModel, this.regModel.id + '');
      try {


        this.getData();
        this.showNew = false;
        this.regModel = {} as LibroDTO;
        this.showAlert("Exito", "Se ha actualizado el libro correctamente");

      } catch (error: any) {
        console.log(error);
        this.showAlert("Error", error.error);
      }


    }

  }

  onEdit(id: number) {
    this.selectedRow = id;
    this.regModel = {} as LibroDTO;
    this.regModel = Object.assign({}, this.libros.find(i => i.id === this.selectedRow));
    this.submitType = 'Actualizar';
    this.showNew = true;
  }

  async onDelete(id: number) {
    try {
      const response = await this.libroservice.deleteAsync(id + '');
      this.getData();
      this.showAlert("Exito", "Se ha eliminado el libro correctamente");

    } catch (error: any) {

      this.showAlert("Error", error.error);
    }


  }

  onCancel() {
    this.showNew = false;

  }

  onChangeAutor(autor: AutorDTO) {
    this.regModel.autor = autor;
    this.regModel.autorId = autor.id;

  }
  showAlert(title: string, body: string) {
    if (title == "Error") {
      this.message.class = 'bg-success text-light';
    } else
      if (title == "Exito") {
        this.message.class = 'bg-danger text-light';
      } else {
        this.message.class = 'text-light';

      }
    this.message.body = body;
    this.message.title = title;
    this.show = true;
    setTimeout(() => this.show = false, 5000);

  }

}
