import { Component, OnInit } from '@angular/core';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { AutorDTO } from '../dto/AutorDTO';
import { CiudadDTO } from '../dto/CiudadDTO';
import { MessageToast } from '../dto/MessageToast';
import { AutorService } from '../services/Autor.service';
import { CiudadService } from '../services/Ciudad.service';


@Component({
  selector: 'app-autor',
  templateUrl: './autor.component.html',
  styleUrls: ['./autor.component.css']
})
export class AutorComponent implements OnInit {

  autores: AutorDTO[] = [];
  ciudades: CiudadDTO[] = [];
  regModel: AutorDTO = {} as AutorDTO;
  showNew: Boolean = false;
  submitType: string = 'Guardar';
  selectedRow: number = 0;
  message: MessageToast = {} as MessageToast;
  show: boolean = false;
  constructor(private autorservice: AutorService, private ciudadService: CiudadService) {

  }

  async ngOnInit() {
    await this.getData();
  }

  async getData() {
    this.autores = await this.autorservice.getAllAsync();
    this.ciudades = await this.ciudadService.getAllAsync();
  }

  onNew() {

    this.submitType = 'Guardar';
    this.regModel = { ciudad: { nombre: "seleccione una ciudad", id: 0 } as CiudadDTO } as AutorDTO;
    this.showNew = true;
  }

  async onSave() {
    this.regModel.fechaNacimiento = this.getFecha(this.regModel.dob);
    if (this.submitType === 'Guardar') {
      if (this.regModel.ciudad.id != 0) {

        try {
          const response = await this.autorservice.createAsync(this.regModel);
          console.log(response);
          this.getData();
          this.showNew = false;
          this.regModel = {} as AutorDTO;
          this.showAlert("Exito", "Se ha creado el autor correctamente");
        } catch (error: any) {
          console.log(error);
          this.showAlert("Error", error.error);
        }

      } else {
        this.showAlert("Notificación", "Debe seleccionar una ciudad");
      }
    } else {
      const response = await this.autorservice.updateAsync(this.regModel, this.regModel.id + '');
      try {


        this.getData();
        this.showNew = false;
        this.regModel = {} as AutorDTO;
        this.showAlert("Exito", "Se ha actualizado el autor correctamente");

      } catch (error: any) {
        console.log(error);
        this.showAlert("Error", error.error);
      }


    }

  }

  onEdit(id: number) {
    this.selectedRow = id;
    this.regModel = {} as AutorDTO;
    this.regModel = Object.assign({}, this.autores.find(i => i.id === this.selectedRow));
    this.submitType = 'Actualizar';
    this.showNew = true;
  }

  async onDelete(id: number) {
    try {
      const response = await this.autorservice.deleteAsync(id + '');
      this.getData();
      this.showAlert("Exito", "Se ha eliminado el autor correctamente");

    } catch (error: any) {

      this.showAlert("Error", error.error);
    }


  }

  onCancel() {
    this.showNew = false;

  }

  onChangeCiudad(ciudad: CiudadDTO) {
    this.regModel.ciudad = ciudad;
    this.regModel.ciudadId = ciudad.id;

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

  getFecha(fecha: NgbDateStruct): string {
    return fecha.year + "-" + fecha.month + "-" + fecha.day;
  }

}
