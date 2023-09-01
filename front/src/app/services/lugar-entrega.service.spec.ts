import { TestBed } from '@angular/core/testing';

import { LugarEntregaService } from './lugar-entrega.service';

describe('LugarEntregaService', () => {
  let service: LugarEntregaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LugarEntregaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
