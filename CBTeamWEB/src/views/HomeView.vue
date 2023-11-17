<script setup lang="ts">
import Card from 'primevue/card';
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import { onMounted, ref } from 'vue';

const users = ref([]);

const getusersList = async () => {
    const response = await fetch('https://localhost:44374/api/users');
    const data = await response.json();
    users.value = data;
  }

onMounted(async () =>{
  await getusersList();
});

</script>


<template>
  <div class="grid">
    <div class="col-12">
      <div class="card">
      <Card>
          <template #title> Listado de Usuarios </template>
          <template #content>
              <p class="m-0">
                  Lorem ipsum dolor sit amet, consectetur adipisicing elit. Inventore sed consequuntur error repudiandae numquam deserunt quisquam repellat libero asperiores earum nam nobis, culpa ratione quam perferendis esse, cupiditate neque
                  quas!
              </p>
          </template>
      </Card>
  </div>
    </div>
  </div>
  <div class="grid">
    <div class="col-12">
      <DataTable :value="users" table-style="min-width: 50rem">
        <Column field="id" header="#"></Column>
        <Column field="name" header="Nombre"></Column>
        <Column field="rolId" header="Rol"></Column>
      </DataTable>
    </div>
  </div>
</template>

