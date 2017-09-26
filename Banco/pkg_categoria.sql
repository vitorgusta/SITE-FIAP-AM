create or replace package pkg_categoria is  

  procedure prc_insere (p_categoria varchar2, p_sta_ativo varchar2);
  
  procedure prc_altera (p_id number, p_categoria varchar2, p_sta_ativo varchar2);
  
  procedure prc_deleta (p_id number);

end pkg_categoria;
/
create or replace package body pkg_categoria is 
  
  procedure prc_insere (p_categoria varchar2, p_sta_ativo varchar2) is 
  
    if p_categoria is not null and p_sta_ativo is not null then 
    
      insert into go_categoria (id
                               ,categoria
                               ,sta_ativo) values (seq_categoria.nextval
                                                  ,p_categoria
                                                  ,p_sta_ativo);
                                                  
    else 

        Raise_Application_Error (-20343, 'Favor preencher todas as informaçoes obrigatorias');
    
    end if;
  
  end prc_insere;
  
  procedure prc_altera (p_id number, p_categoria varchar2,p_sta_ativo varchar2) is 
  
    v_linha_antiga go_categoria%rowtype;
  
    v_historico varchar2(1000);
  begin 
    select * 
    into v_linha_antiga
    from go_categoria
    where id = p_id;
    
    if p_categoria != v_linha_antiga.categoria then 
      
      v_historico := 'Categoria anterior: '||v_linha_antiga.categoria||chr(13);
      
    end if;
    
    if p_sta_ativo != v_linha_antiga.sta_ativo then 
    
      if p_sta_ativo = 'N' then 
        
        v_historico := v_historico||'Categoria desativada'||chr(13);
      
      elsif p_sta_ativo = 'S' then  
        
        v_historico := v_historico||'Categoria Ativada'||chr(13);
      
      end if;
      
    end if;
    
    update go_categoria
    set categoria = p_categoria
    ,   sta_ativo = p_sta_ativo
    where id = p_id;
    
    prc_insere_auditoria('GO_CATEGORIA','UPDATE',v_historico,p_usuario);
    
    exception when no_data_found then 
    
        Raise_Application_Error (-20343, 'Categoria não encontrada');
        
  end prc_altera;

 procedure prc_deleta (p_id number) is

   v_count_noticia number;
  
 begin 
 
   select count(1)
   into v_count_noticia
   from go_noticias
   where go_categoria_id = p_id;
 
   if v_count_noticia != 0 then 
   
    Raise_Application_Error (-20343, 'Já existem noticias cadastradas com esta categoria, favor deletar as noticias.');
   
   else 
      
      delete go_categoria
      where id = p_id;
      
      prc_insere_auditoria('GO_CATEGORIA','DELETE',null,p_usuario);
    
   end if;
 
 end prc_deleta;
end pkg_categoria;
/